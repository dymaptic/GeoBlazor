$SourceFiles = "./node_modules/@arcgis/core/assets/*"
$OutputDir = "./wwwroot/assets"

if ((Test-Path -Path './wwwroot/assets/*') -eq $false)
{
    try
    {
        Write-Output "Copying Assets to wwwroot/assets"
        Copy-Item -Path $SourceFiles -Destination $OutputDir -Recurse -Verbose   
    }
    catch
    {
        Write-Output $_
        Write-Output "We ran into an issue while copying assets to wwwroot/assets. Deleting the copied files..."
        Remove-Item './wwwroot/assets/*' -Recurse -Verbose
        pause
    }
}
else
{
    Write-Output "Asset files already copied. To update, delete wwwroot/assets contents and run again"    
}

