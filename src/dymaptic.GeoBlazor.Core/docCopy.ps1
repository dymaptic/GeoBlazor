$FrontMatter = "---`nlayout: page`nparent: Components`n---`n"
$Directory = ".\Documentation"
$NewPath = "..\..\docs\pages\components"
Get-ChildItem -Path $Directory -Filter "*.md" | 
        ForEach {
            $FrontMatter + ((Get-Content $_.FullName -raw) -replace '.md', '.html') |
                    Out-File $_.FullName; Move-Item -Path $_.FullName -Destination $NewPath
        }