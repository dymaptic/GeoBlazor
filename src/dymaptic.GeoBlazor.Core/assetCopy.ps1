$SourceFiles = "./node_modules/@arcgis/core/assets/*"
$OutputDir = "./wwwroot/assets"

if ((Test-Path -Path './wwwroot/assets/*') -eq $false)
{
    Write-Output "Copying Assets to wwwroot/assets"
    Copy-Item -Path $SourceFiles -Destination $OutputDir -Recurse -Verbose
}
else
{
    Write-Output "Asset files already copied. To update, delete wwwroot/assets contents and run again"    
}
