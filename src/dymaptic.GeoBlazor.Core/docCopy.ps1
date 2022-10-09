$FrontMatter = "---`nlayout: default`nparent: Components`ntitle: "
$EndMatter = "`n---`n"
$SourcePath = ".\Documentation"
$OutPath = "..\..\docs\pages\components"

Get-ChildItem -Path $OutPath -Include *.* -Exclude 'components.md' -File -Recurse | foreach { $_.Delete()}
Get-ChildItem -Path $SourcePath -Filter "*.md" |
        ForEach {
            "$($FrontMatter)$($_.BaseName)$($EndMatter)$(Get-Content $_.FullName -raw)" -replace '.md', '.html' |
                    Out-File $_.FullName -Encoding utf8NoBOM;
                             Copy-Item -Path $_.FullName -Destination $OutPath -Force
        }