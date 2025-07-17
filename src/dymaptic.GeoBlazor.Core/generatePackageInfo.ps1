param([string]$packageId, [string]$path)

Write-Host "Generating PackageInfo.cs with PackageId: $packageId"

$Content = @"
// Auto-generated
namespace dymaptic.GeoBlazor.Core;

internal static class PackageInfo
{
    public const string PackageId = "$packageId";
}
"@

Write-Host "Writing to $path"

try
{
    # Ensure the directory exists
    $directory = Split-Path -Path $path -Parent
    if (-not (Test-Path -Path $directory)) {
        New-Item -ItemType Directory -Path $directory -Force | Out-Null
    }
    Set-Content -Path $path -Value $Content -Force -ErrorAction Stop -Encoding UTF8NoBOM
    Write-Host "PackageInfo.cs generated successfully."
}
catch
{
    Write-Host "Error generating PackageInfo.cs: $_"
    exit 1
}