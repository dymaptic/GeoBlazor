# PowerShell
param([string][Alias("c")]$Configuration = "Debug")

$CoreRootDir = Join-Path -Path $PSScriptRoot "src\dymaptic.GeoBlazor.Core"
$ProRootDir = Join-Path -Path $PSScriptRoot "..\src\dymaptic.GeoBlazor.Pro"
$CoreLockFilePath = Join-Path -Path $CoreRootDir "esBuild.$Configuration.lock"
$ProLockFilePath = Join-Path -Path $ProRootDir "esBuild.$Configuration.lock"

Write-Host "Waiting for lock file:" $LockFilePath

if ((Test-Path -Path $CoreLockFilePath) -or (Test-Path -Path $ProLockFilePath)) {
    Write-Host "Lock file found. Waiting for release."
} else {
    Write-Host "No lock file found. Exiting."
    return 0
}

while ((Test-Path -Path $CoreLockFilePath) -or (Test-Path -Path $ProLockFilePath)) {
    Start-Sleep -Seconds 1
    Write-Host -NoNewline "."
}

Write-Host "Lock file removed. Exiting."
exit 0
