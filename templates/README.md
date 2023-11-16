This package contains simple project templates for the GeoBlazor package. It is designed to allow users to easily create a new project with the GeoBlazor package installed and configured.

There are currently four templates available:

Web Serer app (Server-side Blazor)

Web Assembly App (Client-side Blazor)

Maui Hybrid Blazor App

Web App (Client/Server hybrid Blazor)


to install this template package from this folder, run:
```
dotnet new install .\
```
(MacOS\Linux users should reverse the slash)

to install from nuget package, run:
```
dotnet new install ..PATH_TO_NUGET_SOURCE\GeoBlazor.Templates.1.0.0.nupkg
```

to create a new GeoBlazor Server project run:
```
dotnet new geoblazor-server -p <project name>
```

to create a new GeoBlazor Web Assembly app project run:
```
dotnet new geoblazor-webassembly -p <project name>
```

to create a new GeoBlazor Maui app project run:
```
dotnet new geoblazor-maui -p <project name>
```

to create a new GeoBlazor Web App (.net 8) project run:
```
dotnet new geoblazor-webassembly -p <project name>
```

finally, if you want to remove this package you can run:

```
dotnet new uninstall GeoBlazor.Templates
```