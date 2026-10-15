# GeoBlazor.Templates

<img src="GeoBlazor_Logo.png" alt="GeoBlazor Logo" width="50"/>

[![NuGet](https://img.shields.io/nuget/v/dymaptic.GeoBlazor.Templates.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/dymaptic.GeoBlazor.Templates/)
[![Downloads](https://img.shields.io/nuget/dt/dymaptic.GeoBlazor.Templates?logo=nuget&label=downloads)](https://www.nuget.org/stats/packages/dymaptic.GeoBlazor.Templates?groupby=Version)

This package contains simple project templates for the GeoBlazor package. It is designed to allow users to easily create a new project with the GeoBlazor package installed and configured.

To install this template package run:
```
dotnet new install dymaptic.GeoBlazor.Templates
```

To create a new GeoBlazor application from the command line, we suggest checking the options with the help command:
```
dotnet new geoblazor -h
```

To create a new GeoBlazor Web App project run a command like this:
```
dotnet new geoblazor -int <interactivity_mode> -o <project_name>
```

To create a new GeoBlazor WebAssembly standalone app project run:
```
dotnet new geoblazor-wasm -int <interactivity_mode> -o <project_name>
```

To create a new GeoBlazor Maui app project run:
```
dotnet new geoblazor-maui -o <project_name>
```

To create a new GeoBlazor Maui and Web app in a single solution run:
```
dotnet new geoblazor-maui-web -int <interactivity_mode> -o <project_name>
```

You can also see all the options inside of Visual Studio or Rider when creating a new project.

Finally, if you want to remove this package you can run:

```
dotnet new uninstall dymaptic.GeoBlazor.Templates
```