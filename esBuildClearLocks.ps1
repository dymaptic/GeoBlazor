Remove-Item -Path (Join-Path $PSScriptRoot "src/dymaptic.GeoBlazor.Core/esBuild.Debug.lock") -Force
Remove-Item -Path (Join-Path $PSScriptRoot "src/dymaptic.GeoBlazor.Core/esBuild.Release.lock") -Force
Remove-Item -Path (Join-Path $PSScriptRoot "../src/dymaptic.GeoBlazor.Pro/esProBuild.Debug.lock") -Force
Remove-Item -Path (Join-Path $PSScriptRoot "../src/dymaptic.GeoBlazor.Pro/esProBuild.Release.lock") -Force
Write-Host "Cleared esBuild lock files"