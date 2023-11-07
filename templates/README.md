This package contains simple project templates for the GeoBlazor package. It is designed to allow users to easily create a new project with the GeoBlazor package installed and configured.

There are currently two templates available:

Web App (Server-side Blazor)

Web Assembly App (Client-side Blazor)

to install this template package run:
```
dotnet new install GeoBlazor.Templates
```

to create a new Web App project run:
```
dotnet new geoblazortemplateserver -p <project name>
```

to create a new Web Assembly app project run:
```
dotnet new geoblazortemplatewebassembly -p <project name>
```

finally, if you want to remove this package you can run:

```
dotnet new uninstall GeoBlazor.Templates
```