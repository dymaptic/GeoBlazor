$CoreDebugLock = Join-Path $PSScriptRoot "src/dymaptic.GeoBlazor.Core/esBuild.Debug.lock"
$CoreReleaseLock = Join-Path $PSScriptRoot "src/dymaptic.GeoBlazor.Core/esBuild.Release.lock"
$ProDebugLock = Join-Path $PSScriptRoot "../src/dymaptic.GeoBlazor.Pro/esProBuild.Debug.lock"
$ProReleaseLock = Join-Path $PSScriptRoot "../src/dymaptic.GeoBlazor.Pro/esProBuild.Release.lock"
if (Test-Path $CoreDebugLock)
{
    Remove-Item -Path $CoreDebugLock -Force
}
if (Test-Path $CoreReleaseLock)
{
    Remove-Item -Path $CoreReleaseLock -Force
}
if (Test-Path $ProDebugLock)
{
    Remove-Item -Path $ProDebugLock -Force
}
if (Test-Path $ProReleaseLock)
{
    Remove-Item -Path $ProReleaseLock -Force
}

Write-Host "Cleared esBuild lock files"