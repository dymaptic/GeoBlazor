# PowerShell
param([string][Alias("c")]$Configuration = "Debug")

$CoreRootDir = Join-Path -Path $PSScriptRoot "src\dymaptic.GeoBlazor.Core"
$ProRootDir = Join-Path -Path $PSScriptRoot "..\src\dymaptic.GeoBlazor.Pro"
$CoreLockFilePath = Join-Path -Path $CoreRootDir "esBuild.$Configuration.lock"
$ProLockFilePath = Join-Path -Path $ProRootDir "esBuild.$Configuration.lock"

Write-Host "Waiting for lock files: $CoreLockFilePath, $ProLockFilePath"

if ((Test-Path -Path $CoreLockFilePath) -or (Test-Path -Path $ProLockFilePath)) {
    Write-Host "Lock file found. Waiting for release."
} else {
    Write-Host "No lock file found. Exiting."
    return 0
}

$timeout = 30
$elapsed = 0

while ((Test-Path -Path $CoreLockFilePath) -or (Test-Path -Path $ProLockFilePath)) {
    Start-Sleep -Seconds 1
    Write-Host -NoNewline "."
    $elapsed++

    if ($elapsed -ge $timeout) {
        Write-Host ""
        Write-Host "Timeout reached ($timeout seconds). Deleting lock files."
        if (Test-Path -Path $CoreLockFilePath) {
            Remove-Item -Path $CoreLockFilePath -Force
            Write-Host "Deleted: $CoreLockFilePath"
        }
        if (Test-Path -Path $ProLockFilePath) {
            Remove-Item -Path $ProLockFilePath -Force
            Write-Host "Deleted: $ProLockFilePath"
        }
        break
    }
}

Write-Host "Lock file removed. Exiting."
exit 0
