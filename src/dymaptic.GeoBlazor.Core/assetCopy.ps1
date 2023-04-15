$SourceFiles = "./node_modules/@arcgis/core/assets/*"
$OutputDir = "./wwwroot/assets"

If ((Get-Content "$OutputDir/ArcGISAssetsVersion.txt") -ne "4.26.2")
{
    Write-Output "Deleting old assets"
    Remove-Item './wwwroot/assets/*' -Recurse -Verbose
}

If ((Test-Path -Path './wwwroot/assets/*') -eq $false)
{
    Try
    {
        Write-Output "Copying Assets to wwwroot/assets"
        Copy-Item -Path $SourceFiles -Destination $OutputDir -Recurse -Verbose
    }
    Catch
    {
        Write-Output $_
        Write-Output "We ran into an issue while copying assets to wwwroot/assets. Deleting the copied files..."
        Remove-Item './wwwroot/assets/*' -Recurse -Verbose
        pause
    }
    
    Write-Output "4.26.2" | Out-File -FilePath "$OutputDir/ArcGISAssetsVersion.txt"
}
Else
{
    Write-Output "Asset files already copied. To update, delete wwwroot/assets contents and run again"
}

