$FrontMatter = "---`nlayout: default`nparent: Components`ntitle: "
$Index = "Index`nnav_order: 1"
$EndMatter = "`n---`n"
$SourcePath = ".\Documentation"
$OutPath = "..\..\docs\pages\components"

Get-ChildItem -Path $OutPath -Include *.* -Exclude 'components.md' -File -Recurse | foreach { $_.Delete()}
Get-ChildItem -Path $SourcePath -Filter "*.md" |
        ForEach { $Title = ($_.BaseName -split '\.')[-1];
            "$($FrontMatter)$($_.BaseName -eq 'index' ? $Index : $Title)$($EndMatter)$(Get-Content $_.FullName -raw)" -replace '.md', '.html' |
                    Out-File $_.FullName -Encoding utf8NoBOM;
                             Copy-Item -Path $_.FullName -Destination $OutPath -Force
        }