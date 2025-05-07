if (-not (Test-Path -Path Resources\Raw)) 
{ 
    New-Item -ItemType Directory -Path Resources\Raw 
}

Copy-Item -Path ..\dymaptic.GeoBlazor.Core.Sample.Shared\wwwroot\pages\* -Destination Resources\Raw -Recurse