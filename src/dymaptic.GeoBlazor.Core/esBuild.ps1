param([string][Alias("c")]$Configuration = "Debug")

cd $PSScriptRoot

$DebugLockFilePath = Join-Path -Path $PSScriptRoot "esBuild.Debug.lock"
$ReleaseLockFilePath = Join-Path -Path $PSScriptRoot "esBuild.Release.lock"
$LockFilePath = if ($Configuration.ToLowerInvariant() -eq "release") { $ReleaseLockFilePath } else { $DebugLockFilePath }

# Check if the process is locked for the current configuration
$Locked = (($Configuration.ToLowerInvariant() -eq "debug") -and ($null -ne (Get-Item -Path $DebugLockFilePath -EA 0))) `
        -or (($Configuration.ToLowerInvariant() -eq "release") -and ($null -ne (Get-Item -Path $ReleaseLockFilePath -EA 0)))

# Prevent multiple instances of the script from running at the same time
if ($Locked)
{
    Write-Output "Another instance of the script is already running. Exiting."
    Exit 0
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
    $HasError = ($Install -like "*Error*")
    $HasWarning = ($Install -like "*Warning*")
    Write-Output "-----"
    if ($HasError -ne $null -or $HasWarning -ne $null)
    {
        Write-Output "NPM Install failed"
        exit 1
    }
    
    if ($Configuration.ToLowerInvariant() -eq "release")
    {
        $Build = npm run releaseBuild 2>&1
        Write-Output $Build
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            exit 1
        }
    }
    else
    {
        $Build = npm run debugBuild 2>&1
        Write-Output $Build
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            exit 1
        }
    }
    Write-Output "NPM Build Complete"
    exit 0
}
catch
{
    Write-Output $_
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