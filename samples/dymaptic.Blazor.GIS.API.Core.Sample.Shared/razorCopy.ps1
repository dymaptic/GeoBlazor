Get-ChildItem -Path .\Pages -Filter "*.razor" -File |
  ForEach-Object { Copy-Item -Path $_.FullName -Destination ".\wwwroot\pages\$($_.BaseName).html" }