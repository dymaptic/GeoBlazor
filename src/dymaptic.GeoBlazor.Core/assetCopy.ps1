if ($IsWindows)
{
    $SourceFiles = "./node_modules/@arcgis/core/assets/*"    
}
else
{
    $SourceFiles = "./node_modules/@arcgis/core/assets/"
}

$OutputDir = "./wwwroot/assets"
$packageJson = (Get-Content "./package.json" -Raw) | ConvertFrom-Json
# read the version from package.json
$ArcGISVersion = $packageJson.dependencies."@arcgis/core"
# remove the ^ from the version
$ArcGISVersion = $ArcGISVersion.Replace("^", "")

if ((Test-Path -Path "$OutputDir/ArcGISAssetsVersion.txt") -eq $true)
{
    If ((Get-Content "$OutputDir/ArcGISAssetsVersion.txt") -ne $ArcGISVersion)
    {
        Write-Output "Deleting old assets"
        Remove-Item './wwwroot/assets/*' -Recurse
    }
}

If ((Test-Path -Path './wwwroot/assets/*') -eq $false)
{
    Try
    {
        Write-Output "Copying Assets to wwwroot/assets"
        Copy-Item -Path $SourceFiles -Destination $OutputDir -Recurse
    }
    Catch
    {
        Write-Output $_
        Write-Output "We ran into an issue while copying assets to wwwroot/assets. Deleting the copied files..."
        Remove-Item './wwwroot/assets/*' -Recurse
        pause
    }

    Write-Output $ArcGISVersion | Out-File -FilePath "$OutputDir/ArcGISAssetsVersion.txt"
}
Else
{
    Write-Output "Asset files already copied. To update, delete wwwroot/assets contents and run again"
}

