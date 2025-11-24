# PowerShell
param([string][Alias("c")]$Configuration = "Debug",
    [switch]$Pro)

if ($Pro) {
    $RootDir = Join-Path -Path $PSScriptRoot "..\src\dymaptic.GeoBlazor.Pro"
} else {
    $RootDir = Join-Path -Path $PSScriptRoot "src\dymaptic.GeoBlazor.Core"
}

$LockFilePath = Join-Path -Path $RootDir "esBuild.$Configuration.lock"

Write-Host "Waiting for lock file:" $LockFilePath

if (Test-Path -Path $LockFilePath) {
    Write-Host "Lock file found. Waiting for release."
} else {
    Start-Sleep -Seconds 1
    if (Test-Path -Path $LockFilePath) {
        Write-Host "Lock file found. Waiting for release."
    } else {
        Write-Host "No lock file found. Exiting."
        return 0
    }
}

while (Test-Path -Path $LockFilePath) {
    Start-Sleep -Seconds 1
    Write-Host -NoNewline "."
}

Write-Host "Lock file removed. Exiting."
exit 0
