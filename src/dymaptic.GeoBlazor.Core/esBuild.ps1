param([string][Alias("c")]$Configuration = "Debug",
      [switch][Alias("f")]$Force,
      [switch][Alias("h")]$Help)

# Allow $IsLinux and $IsMacOS to be accessed safely in Windows PowerShell
Set-StrictMode -Off

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
if ($Force)
{
    if (Test-Path $RecordFilePath)
    {
        Write-Host "Force rebuild: Deleting existing record file."
        Remove-Item -Path $RecordFilePath -Force
    }
}

function Get-CurrentGitBranch
{
    try
    {
        $branch = git rev-parse --abbrev-ref HEAD 2> $null
        if ($LASTEXITCODE -eq 0)
        {
            return $branch.Trim()
        }
        return "unknown"
    }
    catch
    {
        return "unknown"
    }
}

function Get-LastBuildRecord
{
    if (-not (Test-Path $RecordFilePath))
    {
        return @{ timestamp = 0; branch = "unknown" }
    }
    try
    {
        $data = Get-Content -Path $RecordFilePath -Raw | ConvertFrom-Json
        return @{
            timestamp = if ($data.timestamp)
            {
                $data.timestamp
            }
            else
            {
                0
            }
            branch = if ($data.branch)
            {
                $data.branch
            }
            else
            {
                "unknown"
            }
        }
    }
    catch
    {
        return @{ timestamp = 0; branch = "unknown" }
    }
}

function Get-ScriptsModifiedSince
{
    param([long]$LastTimestamp)

    # Convert JavaScript timestamp (milliseconds) to DateTime
    $lastBuildTime = [DateTimeOffset]::FromUnixTimeMilliseconds($LastTimestamp).DateTime

    $files = Get-ChildItem -Path $ScriptsDir -Recurse -File
    foreach ($file in $files)
    {
        if ($file.LastWriteTime -gt $lastBuildTime)
        {
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
if ($branchChanged)
{
    Write-Host "Git branch changed from `"$( $lastBuild.branch )`" to `"$currentBranch`". Rebuilding..."
    $needsBuild = $true
}
elseif (-not (Get-ScriptsModifiedSince -LastTimestamp $lastBuild.timestamp))
{
    Write-Host "No changes in Scripts folder since last build."

    # Check output directory for existing files
    if ((Test-Path $OutputDir) -and ((Get-ChildItem -Path $OutputDir -File).Count -gt 0))
    {
        Write-Host "Output directory is not empty. Skipping build."
        exit 0
    }
    else
    {
        Write-Host "Output directory is empty. Proceeding with build."
        $needsBuild = $true
    }
}
else
{
    Write-Host "Changes detected in Scripts folder. Proceeding with build."
    $needsBuild = $true
}

if (-not $needsBuild)
{
    exit 0
}

function WriteToDialog
{
    param([System.Diagnostics.Process]$DialogProcess,
        [string]$Content)
    if ($DialogProcess.StandardInput -eq $null)
    {
        return;
    }

    $DialogProcess.StandardInput.WriteLine($Content);
}

# Start dialog process only if we're actually going to build
$ConsoleDialogPath = Join-Path -Path $PSScriptRoot ".." ".." "build"
$DialogStartInfo = New-Object System.Diagnostics.ProcessStartInfo
$DialogStartInfo.FileName = "dotnet"
$DialogStartInfo.WorkingDirectory = $ConsoleDialogPath
$DialogStartInfo.Arguments = "ConsoleDialog.cs `"GeoBlazor Core ESBuild`""
$DialogStartInfo.RedirectStandardInput = $true
$DialogStartInfo.RedirectStandardOutput = $true
$DialogStartInfo.UseShellExecute = $false

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
        WriteToDialog -DialogProcess $DialogProcess -Content $line
    }
    $HasError = ($Install -like "*Error*")
    $HasWarning = ($Install -like "*Warning*")
    Write-Output "-----"
    WriteToDialog -DialogProcess $DialogProcess -Content "-----"
    if ($HasError -ne $null -or $HasWarning -ne $null)
    {
        Write-Output "NPM Install failed"
        WriteToDialog -DialogProcess $DialogProcess -Content "NPM Install failed"
        WriteToDialog -DialogProcess $DialogProcess -Content "hold"
        exit 1
    }

    # Run ESLint before build
    Write-Output "Running ESLint..."
    WriteToDialog -DialogProcess $DialogProcess -Content "Running ESLint..."
    $Lint = npm run lint 2>&1
    Write-Output $Lint
    foreach ($line in $Lint)
    {
        WriteToDialog -DialogProcess $DialogProcess -Content $line
    }
    $LintHasError = ($Lint -like "*error*")
    if ($LintHasError -ne $null)
    {
        Write-Output "ESLint found errors"
        WriteToDialog -DialogProcess $DialogProcess -Content "ESLint found errors"
        WriteToDialog -DialogProcess $DialogProcess -Content "hold"
        exit 1
    }
    Write-Output "-----"
    WriteToDialog -DialogProcess $DialogProcess -Content "-----"

    if ($Configuration.ToLowerInvariant() -eq "release")
    {
        $Build = npm run releaseBuild 2>&1
        Write-Output $Build
        foreach ($line in $Build)
        {
            WriteToDialog -DialogProcess $DialogProcess -Content $line
        }
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        WriteToDialog -DialogProcess $DialogProcess -Content "-----"
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            WriteToDialog -DialogProcess $DialogProcess -Content "hold"
            exit 1
        }
    }
    else
    {
        $Build = npm run debugBuild 2>&1
        Write-Output $Build
        foreach ($line in $Build)
        {
            WriteToDialog -DialogProcess $DialogProcess -Content $line
        }
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        WriteToDialog -DialogProcess $DialogProcess -Content "-----"
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            WriteToDialog -DialogProcess $DialogProcess -Content "hold"
            exit 1
        }
    }
    Write-Output "NPM Build Complete"
    WriteToDialog -DialogProcess $DialogProcess -Content "NPM Build Complete"
    WriteToDialog -DialogProcess $DialogProcess -Content "exit"
    exit 0
}
catch
{
    Write-Output "An error occurred in esBuild.ps1"
    WriteToDialog -DialogProcess $DialogProcess -Content "An error occurred in esBuild.ps1"
    Write-Output $_
    WriteToDialog -DialogProcess $DialogProcess -Content $_
    WriteToDialog -DialogProcess $DialogProcess -Content "hold"
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