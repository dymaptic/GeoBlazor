<#
.SYNOPSIS
    Generates appsettings.json files for test applications.

.DESCRIPTION
    Creates appsettings.json files at the specified paths with the provided configuration values.

.PARAMETER ArcGISApiKey
    The ArcGIS API key for map services.

.PARAMETER LicenseKey
    The GeoBlazor license key.

.PARAMETER OutputPaths
    Array of file paths where appsettings.json should be written.

.PARAMETER DocsUrl
    The documentation URL. Defaults to "https://docs.geoblazor.com".

.PARAMETER ByPassApiKey
    The API bypass key for samples.

.PARAMETER WfsServers
    Additional WFS server configuration (JSON fragment without outer braces).

.EXAMPLE
    ./buildAppSettings.ps1 -ArcGISApiKey "your-key" -LicenseKey "your-license" -OutputPaths @("./appsettings.json")

.EXAMPLE
    ./buildAppSettings.ps1 -ArcGISApiKey "key" -LicenseKey "license" -OutputPaths @("./app1/appsettings.json", "./app2/appsettings.json")
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$ArcGISApiKey,

    [Parameter(Mandatory = $true)]
    [string]$LicenseKey,

    [Parameter(Mandatory = $true)]
    [string[]]$OutputPaths,

    [Parameter(Mandatory = $false)]
    [string]$DocsUrl = "https://docs.geoblazor.com",

    [Parameter(Mandatory = $false)]
    [string]$ByPassApiKey = "",

    [Parameter(Mandatory = $false)]
    [string]$WfsServers = ""
)

# Build the appsettings JSON content
$appSettingsContent = @"
{
  "ArcGISApiKey": "$ArcGISApiKey",
  "GeoBlazor": {
    "LicenseKey": "$LicenseKey"
  },
  "DocsUrl": "$DocsUrl",
  "ByPassApiKey": "$ByPassApiKey"
"@

# Add WFS servers if provided
if ($WfsServers -ne "") {
    $appSettingsContent += ",`n  $WfsServers"
}

$appSettingsContent += "`n}"

# Write to each target path
foreach ($path in $OutputPaths) {
    $directory = Split-Path -Parent $path
    if ($directory -and !(Test-Path $directory)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    if (!(Test-Path $path)) {
        New-Item -ItemType File -Path $path -Force | Out-Null
    }
    $appSettingsContent | Out-File -FilePath $path -Encoding utf8
    Write-Host "Created: $path"
}

Write-Host "AppSettings files generated successfully."
