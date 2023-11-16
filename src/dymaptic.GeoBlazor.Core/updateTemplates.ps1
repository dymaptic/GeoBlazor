$CoreVersion = $args[0]

(Get-Content ..\..\templates\content\GeoBlazor.Template.Maui\GeoBlazor.Template.Maui.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\GeoBlazor.Template.Maui\GeoBlazor.Template.Maui.csproj

(Get-Content ..\..\templates\content\GeoBlazor.Template.Server\GeoBlazor.Template.Server.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\GeoBlazor.Template.Server\GeoBlazor.Template.Server.csproj

(Get-Content ..\..\templates\content\GeoBlazor.Template.WebAssembly\GeoBlazor.Template.WebAssembly.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\GeoBlazor.Template.WebAssembly\GeoBlazor.Template.WebAssembly.csproj

(Get-Content ..\..\templates\content\GeoBlazor.Template.WebApp\GeoBlazor.Template.WebApp\GeoBlazor.Template.WebApp.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\GeoBlazor.Template.WebApp\GeoBlazor.Template.WebApp\GeoBlazor.Template.WebApp.csproj

(Get-Content ..\..\templates\content\GeoBlazor.Template.WebApp\GeoBlazor.Template.WebApp.Client\GeoBlazor.Template.WebApp.Client.csproj) `
-replace '\<PackageReference Include="dymaptic.GeoBlazor.Core" Version="[\d\.]*"', ('<PackageReference Include="dymaptic.GeoBlazor.Core" Version="' + $CoreVersion + '"') | 
Set-Content ..\..\templates\content\GeoBlazor.Template.WebApp\GeoBlazor.Template.WebApp.Client\GeoBlazor.Template.WebApp.Client.csproj