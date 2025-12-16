param ([string]$Content)

if ($null -eq $Content -or $Content -eq "") {
    Write-Error "Content parameter is required."
    exit 1
}

# Define the destination path
$destinationPath = Join-Path $PSScriptRoot "Scripts" "geoblazorProto.ts"

# Unescape any escaped characters in the content
$Content = $Content -replace '\\"', '"' -replace '\\r\\n', "`r`n" -replace '\\n', "`n"

Set-Content -Path $destinationPath -Value $Content -Encoding UTF8