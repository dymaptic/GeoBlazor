This package contains simple project templates for the GeoBlazor package. It is designed to allow users to easily create a new project with the GeoBlazor package installed and configured.

There are currently four templates available:

Web Server app (Server-side Blazor)

Web Assembly App (Client-side Blazor)

Maui Hybrid Blazor App

Web App (Client/Server hybrid Blazor)


to install this template package run:
```
dotnet new install dymaptic.GeoBlazor.Templates
```

to create a new GeoBlazor Server project run:
```
dotnet new geoblazor-server -o <project name>
```

to create a new GeoBlazor Web Assembly app project run:
```
dotnet new geoblazor-webassembly -o <project name>
```

to create a new GeoBlazor Maui app project run:
```
dotnet new geoblazor-maui -o <project name>
```

to create a new GeoBlazor Web App (.net 8) project run:
```
dotnet new geoblazor-webassembly -o <project name>
```

finally, if you want to remove this package you can run:

```
dotnet new uninstall dymaptic.GeoBlazor.Templates
```