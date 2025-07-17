$ArcGISSourceFiles = Join-Path $PSScriptRoot "node_modules/@arcgis/core/assets/*"
$ArcGISComponentsSourceFiles = Join-Path $PSScriptRoot "node_modules/@arcgis/map-components/dist/cdn/assets/*"
$CalciteSourceFiles = Join-Path $PSScriptRoot "node_modules/@esri/calcite-components/dist/calcite/assets/*"

$packageJson = (Get-Content (Join-Path $PSScriptRoot "package.json") -Raw) | ConvertFrom-Json
# read the version from package.json
$ArcGISVersion = $packageJson.dependencies."@arcgis/core".Replace("^", "")

$OutputRootDir = Join-Path $PSScriptRoot "wwwroot/assets"

$ArcGISOutputDir = Join-Path $OutputRootDir $ArcGISVersion.Replace(".", "_")
$ArcGISComponentsOutputDir = Join-Path $ArcGISOutputDir "map-components"
$CalciteOutputDir = Join-Path $ArcGISOutputDir "calcite"
$OutputDeleteRegex = Join-Path $OutputRootDir "*"

if (((Test-Path -Path "$OutputRootDir/ArcGISAssetsVersion.txt") -eq $false -or `
    (Get-Content "$OutputRootDir/ArcGISAssetsVersion.txt") -ne $ArcGISVersion) -and `
    (Test-Path -Path $OutputDeleteRegex) -eq $true)
{
    Write-Output "Deleting old assets"
    Remove-Item $OutputDeleteRegex -Recurse
}

If ((Test-Path -Path $OutputDeleteRegex) -eq $false)
{
    Try
    {
        Write-Output "Copying ArcGIS Assets to $ArcGISOutputDir"
        # create the output directory if it does not exist
        If ((Test-Path -Path $ArcGISOutputDir) -eq $false)
        {
            New-Item -ItemType Directory -Path $ArcGISOutputDir | Out-Null
        }
        
        # run NPM install to ensure the assets are available
        npm install
        Copy-Item -Path $ArcGISSourceFiles -Destination $ArcGISOutputDir -Recurse
        
        Write-Output "Copying ArcGIS Map Components Assets to $ArcGISComponentsOutputDir"
        # create the map-components directory if it does not exist
        If ((Test-Path -Path $ArcGISComponentsOutputDir) -eq $false)
        {
            New-Item -ItemType Directory -Path $ArcGISComponentsOutputDir | Out-Null
        }
        
        Copy-Item -Path $ArcGISComponentsSourceFiles -Destination $ArcGISComponentsOutputDir -Recurse
        
        Write-Output "Copying Calcite Assets to $CalciteOutputDir"
        # create the calcite directory if it does not exist
        If ((Test-Path -Path $CalciteOutputDir) -eq $false)
        {
            New-Item -ItemType Directory -Path $CalciteOutputDir | Out-Null
        }
        Copy-Item -Path $CalciteSourceFiles -Destination $CalciteOutputDir -Recurse
    }
    Catch
    {
        Write-Output $_
        Write-Output "We ran into an issue while copying assets to wwwroot/assets. Deleting the copied files..."
        Remove-Item $OutputDeleteRegex -Recurse
        return
    }

    Write-Output $ArcGISVersion | Out-File -FilePath "$OutputRootDir/ArcGISAssetsVersion.txt"
}
Else
{
    Write-Output "Asset files already copied. To update, delete wwwroot/assets contents and run again"
}