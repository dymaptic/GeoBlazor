param ([string][Alias("c")]$Configuration = "Debug",
[string][Alias("tfm")]$TargetFramework = "net8.0")

# Find the GeoBlazorProto.g.cs file in the intermediate output path
$sourcePath = Join-Path $PSScriptRoot "obj" $Configuration `
    $TargetFramework "generated" `
    "dymaptic.GeoBlazor.Core.SourceGenerator" `
    "dymaptic.GeoBlazor.Core.SourceGenerator.ProtobufDefinitionsGenerator" `
    "GeoBlazorProto.g.cs"

# Define the destination path
$destinationPath = Join-Path $PSScriptRoot "wwwroot" "geoblazor.proto"

# Extract the content of the @"..." block
$allContent = Get-Content $sourcePath -Raw

$contentPattern = '@"\s*(.*)\s*---'

$contentMatch = [regex]::Match($allContent, $contentPattern, [System.Text.RegularExpressions.RegexOptions]::Singleline)
if (-not $contentMatch.Success) {
    throw "Could not find the protobuf content block in the source file."
}

# Write the content to the destination file
$protobufContent = $contentMatch.Groups[1].Value

# replace escaped quotes
$protobufContent = $protobufContent -replace '""', '"'
Set-Content -Path $destinationPath -Value $protobufContent -Encoding UTF8