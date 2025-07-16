$SourceFiles = Join-Path $PSScriptRoot "node_modules/@arcgis/core/assets/"

$packageJson = (Get-Content (Join-Path $PSScriptRoot "package.json") -Raw) | ConvertFrom-Json
# read the version from package.json
$ArcGISVersion = $packageJson.dependencies."@arcgis/core"
# remove the ^ from the version
$ArcGISVersion = $ArcGISVersion.Replace("^", "")

$OutputRootDir = Join-Path $PSScriptRoot "wwwroot/assets"

$OutputDir = Join-Path $OutputRootDir $ArcGISVersion.Replace(".", "_")
$OutputDeleteRegex = Join-Path $OutputRootDir "*"

if ((Test-Path -Path "$OutputRootDir/ArcGISAssetsVersion.txt") -eq $true)
{
    If ((Get-Content "$OutputRootDir/ArcGISAssetsVersion.txt") -ne $ArcGISVersion)
    {
        Write-Output "Deleting old assets"
        Remove-Item $OutputDeleteRegex -Recurse
    }
}

If ((Test-Path -Path $OutputDeleteRegex) -eq $false)
{
    Try
    {
        Write-Output "Copying Assets to $OutputDir"
        # create the output directory if it does not exist
        If ((Test-Path -Path $OutputDir) -eq $false)
        {
            New-Item -ItemType Directory -Path $OutputDir | Out-Null
        }
        
        # run NPM install to ensure the assets are available
        npm install
        Copy-Item -Path $SourceFiles -Destination $OutputDir -Recurse
    }
    Catch
    {
        Write-Output $_
        Write-Output "We ran into an issue while copying assets to wwwroot/assets. Deleting the copied files..."
        Remove-Item $OutputDeleteRegex -Recurse
        pause
    }

    Write-Output $ArcGISVersion | Out-File -FilePath "$OutputDir/ArcGISAssetsVersion.txt"
}
Else
{
    Write-Output "Asset files already copied. To update, delete wwwroot/assets contents and run again"
}

# if there is a folder called `assets` inside the assets folder, delete it
# and move everything to the root of the assets folder
$assetsFolder = "$OutputDir/assets"
if ((Test-Path -Path $assetsFolder) -eq $true)
{
    Write-Output "Moving assets to root of assets folder"
    Get-ChildItem -Path $assetsFolder -Recurse | Move-Item -Destination $OutputDir
    Remove-Item -Path $assetsFolder -Recurse
}