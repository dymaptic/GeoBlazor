$FrontMatter = "---`nlayout: default`ntitle: "
$Parent = "`nparent: "
$Index = "Index`nnav_order: 1"
$EndMatter = "`n---`n"
$SourcePath = ".\Documentation"
$OutPath = "..\..\docs\pages\classes"

Write-Output "Copying Docs Files"
Get-ChildItem -Path $SourcePath -Filter "*.md" |
        ForEach { $NameComponents = ($_.BaseName -split '\.');
            $Title = $NameComponents[-1];
            $Folder = $NameComponents[-2];
            Write-Output "- $_.BaseName"
            "$($FrontMatter)$($_.BaseName -eq 'index' ? $Index : $Title)$($Parent)Classes$($EndMatter)$(Get-Content $_.FullName -raw)" -replace '.md', '.html' |
                    Out-File $_.FullName -Encoding utf8NoBOM;
                             Copy-Item -Path $_.FullName -Destination "$($OutPath)" -Force
        }


$SourceFiles = "./node_modules/@arcgis/core/assets/*"
$OutputDir = "./wwwroot/assets"

if ((Test-Path -Path './wwwroot/assets/*') -eq $false)
{
    Write-Output "Copying Assets to wwwroot/assets"
    Copy-Item -Path $SourceFiles -Destination $OutputDir -Recurse -Verbose
}
