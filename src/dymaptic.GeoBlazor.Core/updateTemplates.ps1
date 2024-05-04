$CoreVersion = $args[0]

(Get-Content ..\..\templates\dymaptic.GeoBlazor.Templates.csproj) `
-replace '\<PackageVersion\>[\d\.\-\w]*', ('<PackageVersion>' + $CoreVersion) |
Set-Content ..\..\templates\dymaptic.GeoBlazor.Templates.csproj

(Get-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.Maui\dymaptic.GeoBlazor.Template.Maui.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.\-\w]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.Maui\dymaptic.GeoBlazor.Template.Maui.csproj

(Get-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.Server\dymaptic.GeoBlazor.Template.Server.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.\-\w]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.Server\dymaptic.GeoBlazor.Template.Server.csproj

(Get-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.WebAssembly\dymaptic.GeoBlazor.Template.WebAssembly.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.\-\w]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.WebAssembly\dymaptic.GeoBlazor.Template.WebAssembly.csproj

(Get-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.WebApp\dymaptic.GeoBlazor.Template.WebApp\dymaptic.GeoBlazor.Template.WebApp.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.\-\w]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.WebApp\dymaptic.GeoBlazor.Template.WebApp\dymaptic.GeoBlazor.Template.WebApp.csproj

(Get-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.WebApp\dymaptic.GeoBlazor.Template.WebApp.Client\dymaptic.GeoBlazor.Template.WebApp.Client.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.\-\w]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\dymaptic.GeoBlazor.Template.WebApp\dymaptic.GeoBlazor.Template.WebApp.Client\dymaptic.GeoBlazor.Template.WebApp.Client.csproj