$FrontMatter = "---`nlayout: default`ntitle: "
$Parent = "`nparent: "
$Index = "Index`nnav_order: 1"
$EndMatter = "`n---`n"
$SourcePath = ".\Documentation"
$OutPath = "..\..\docs\pages\classes"

Get-ChildItem -Path $OutPath -Include *.* -Exclude 'classes.md' -File -Recurse | foreach { $_.Delete() }
Write-Output "Copying Docs Files"
Get-ChildItem -Path $SourcePath -Filter "*.md" |
        ForEach {
            $NameComponents = ($_.BaseName -split '\.');
            $Title = $NameComponents[-1];
            $Folder = $NameComponents[-2];
            Write-Output "- $_.BaseName"
            "$( $FrontMatter )$( $_.BaseName -eq 'index' ? $Index : $Title )$( $Parent )Classes$( $EndMatter )$( Get-Content $_.FullName -raw )" -replace '.md', '.html' -replace '>[\s]*ArcGIS[\s]*JS API[\s]*</a>', '>ArcGIS JS API</a>' |
                    Out-File $_.FullName -Encoding utf8NoBOM;
            Copy-Item -Path $_.FullName -Destination "$( $OutPath )" -Force
        }