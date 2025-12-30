param([string][Alias("c")]$Configuration = "Debug",
      [switch][Alias("f")]$Force,
      [switch][Alias("h")]$Help)

if ($Help) {
    Write-Host "ESBuild TypeScript -> JavaScript Compilation Script"
    Write-Host ""
    Write-Host "Parameters:"
    Write-Host "  -Force (-f)                    Removes any lock files and forces the script to run"
    Write-Host "  -Configuration (-c) <string>   Build configuration (default is 'Release')"
    Write-Host "                                 Valid values are 'Debug' and 'Release'"
    Write-Host "  -Help (-h)                     Display this help message"
    exit 0
}

cd $PSScriptRoot

$DebugLockFilePath = Join-Path -Path $PSScriptRoot "esBuild.Debug.lock"
$ReleaseLockFilePath = Join-Path -Path $PSScriptRoot "esBuild.Release.lock"
$LockFilePath = if ($Configuration.ToLowerInvariant() -eq "release") { $ReleaseLockFilePath } else { $DebugLockFilePath }

# Check for changes before starting the dialog
$RecordFilePath = Join-Path -Path $PSScriptRoot ".." ".." ".esbuild-record.json"
$ScriptsDir = Join-Path -Path $PSScriptRoot "Scripts"
$OutputDir = Join-Path -Path $PSScriptRoot "wwwroot" "js"

# Handle --force flag: delete record file
if ($Force) {
    if (Test-Path $RecordFilePath) {
        Write-Host "Force rebuild: Deleting existing record file."
        Remove-Item -Path $RecordFilePath -Force
    }
}

function Get-CurrentGitBranch {
    try {
        $branch = git rev-parse --abbrev-ref HEAD 2>$null
        if ($LASTEXITCODE -eq 0) {
            return $branch.Trim()
        }
        return "unknown"
    } catch {
        return "unknown"
    }
}

function Get-LastBuildRecord {
    if (-not (Test-Path $RecordFilePath)) {
        return @{ timestamp = 0; branch = "unknown" }
    }
    try {
        $data = Get-Content -Path $RecordFilePath -Raw | ConvertFrom-Json
        return @{
            timestamp = if ($data.timestamp) { $data.timestamp } else { 0 }
            branch = if ($data.branch) { $data.branch } else { "unknown" }
        }
    } catch {
        return @{ timestamp = 0; branch = "unknown" }
    }
}

function Get-ScriptsModifiedSince {
    param([long]$LastTimestamp)

    # Convert JavaScript timestamp (milliseconds) to DateTime
    $lastBuildTime = [DateTimeOffset]::FromUnixTimeMilliseconds($LastTimestamp).DateTime

    $files = Get-ChildItem -Path $ScriptsDir -Recurse -File
    foreach ($file in $files) {
        if ($file.LastWriteTime -gt $lastBuildTime) {
            return $true
        }
    }
    return $false
}

# Check if build is needed
$lastBuild = Get-LastBuildRecord
$currentBranch = Get-CurrentGitBranch
$branchChanged = $currentBranch -ne $lastBuild.branch

$needsBuild = $false
if ($branchChanged) {
    Write-Host "Git branch changed from `"$($lastBuild.branch)`" to `"$currentBranch`". Rebuilding..."
    $needsBuild = $true
} elseif (-not (Get-ScriptsModifiedSince -LastTimestamp $lastBuild.timestamp)) {
    Write-Host "No changes in Scripts folder since last build."

    # Check output directory for existing files
    if ((Test-Path $OutputDir) -and ((Get-ChildItem -Path $OutputDir -File).Count -gt 0)) {
        Write-Host "Output directory is not empty. Skipping build."
        exit 0
    } else {
        Write-Host "Output directory is empty. Proceeding with build."
        $needsBuild = $true
    }
} else {
    Write-Host "Changes detected in Scripts folder. Proceeding with build."
    $needsBuild = $true
}

if (-not $needsBuild) {
    exit 0
}

# Start dialog process only if we're actually going to build
$ShowDialogPath = Join-Path -Path $PSScriptRoot ".." ".." "showDialog.ps1"
$DialogArgs = "-Message `"Starting GeoBlazor Core ESBuild process...`" -Title `"GeoBlazor Core ESBuild`" -Buttons None -ListenForInput"
$DialogStartInfo = New-Object System.Diagnostics.ProcessStartInfo
$DialogStartInfo.FileName = "pwsh"
$DialogStartInfo.Arguments = "-NoProfile -ExecutionPolicy ByPass -File `"$ShowDialogPath`" $DialogArgs"
$DialogStartInfo.RedirectStandardInput = $true
$DialogStartInfo.UseShellExecute = $false
$DialogStartInfo.CreateNoWindow = $true
$DialogProcess = [System.Diagnostics.Process]::Start($DialogStartInfo)

# Check if the process is locked for the current configuration
$Locked = (($Configuration.ToLowerInvariant() -eq "debug") -and ($null -ne (Get-Item -Path $DebugLockFilePath -EA 0))) `
        -or (($Configuration.ToLowerInvariant() -eq "release") -and ($null -ne (Get-Item -Path $ReleaseLockFilePath -EA 0)))

# Prevent multiple instances of the script from running at the same time
if ($Locked)
{
    if ($Force -eq $true) {
        if (Test-Path $DebugLockFilePath)
        {
            Remove-Item -Path $DebugLockFilePath -Force
        }
        if (Test-Path $ReleaseLockFilePath)
        {
            Remove-Item -Path $ReleaseLockFilePath -Force
        }

        Write-Host "Cleared esBuild lock files"
    } else {
        Write-Output "Another instance of the script is already running. Exiting."
        $DialogProcess.Kill()
        Exit 1   
    }
}

try
{
    # Lock
    New-Item -Path $LockFilePath
    
    ## Delete old assets - from prior to 4.2.x
    ## Eventually we can remove this, but it will make switching branches simpler
    $AssetsPath = Join-Path -Path $PSScriptRoot "wwwroot/assets"
    if (Test-Path $AssetsPath)
    {
        Write-Output "Deleting old assets at $AssetsPath"
        Remove-Item -Path $AssetsPath -Recurse -Force -ErrorAction Stop
    }

    $OutJsPath = Join-Path -Path $PSScriptRoot "wwwroot/js"
    if (-not (Test-Path $OutJsPath))
    {
        New-Item -Path $OutJsPath -ItemType Directory | Out-Null
    }
    
    $Install = npm install 2>&1
    Write-Output $Install
    foreach ($line in $Install)
    {
        $DialogProcess.StandardInput.WriteLine($line)
    }
    $HasError = ($Install -like "*Error*")
    $HasWarning = ($Install -like "*Warning*")
    Write-Output "-----"
    $DialogProcess.StandardInput.WriteLine("-----")
    if ($HasError -ne $null -or $HasWarning -ne $null)
    {
        Write-Output "NPM Install failed"
        $DialogProcess.StandardInput.WriteLine("NPM Install failed")
        exit 1
    }
    
    if ($Configuration.ToLowerInvariant() -eq "release")
    {
        $Build = npm run releaseBuild 2>&1
        Write-Output $Build
        foreach ($line in $Build)
        {
            $DialogProcess.StandardInput.WriteLine($line)
        }
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        $DialogProcess.StandardInput.WriteLine("-----")
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            exit 1
        }
    }
    else
    {
        $Build = npm run debugBuild 2>&1
        Write-Output $Build
        foreach ($line in $Build)
        {
            $DialogProcess.StandardInput.WriteLine($line)
        }
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        $DialogProcess.StandardInput.WriteLine("-----")
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            exit 1
        }
    }
    Write-Output "NPM Build Complete"
    $DialogProcess.StandardInput.WriteLine("NPM Build Complete")
    Start-Sleep -Seconds 4
    $DialogProcess.Kill()
    exit 0
}
catch
{
    Write-Output "An error occurred in esBuild.ps1"
    $DialogProcess.StandardInput.WriteLine("An error occurred in esBuild.ps1")
    Write-Output $_
    $DialogProcess.StandardInput.WriteLine($_)
    exit 1
}
finally
{
    # Unlock
    if (Test-Path -Path $LockFilePath)
    {
        Remove-Item -Path $LockFilePath -Force
    }
}