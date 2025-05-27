# GeoBlazor

## The premier mapping solution for Asp.NET Core Blazor applications.

GeoBlazor brings the power of the ArcGIS Maps SDK for JavaScript into your Blazor applications with 100% C# code - no JavaScript required. Create beautiful, interactive maps with industry-leading geospatial capabilities while maintaining a pure .NET development experience.

[Go GeoBlazor Pro](https://www.nuget.org/packages/dymaptic.GeoBlazor.Pro)

[![Build](https://img.shields.io/github/actions/workflow/status/dymaptic/GeoBlazor/main-release-build.yml?logo=github)](https://github.com/dymaptic/GeoBlazor/actions/workflows/main-release-build.yml)
[![Issues](https://img.shields.io/github/issues/dymaptic/GeoBlazor?logo=github)](https://github.com/dymaptic/GeoBlazor/issues)
[![Pull Requests](https://img.shields.io/github/issues-pr/dymaptic/GeoBlazor?logo=github&color=)](https://github.com/dymaptic/GeoBlazor/pulls)

**CORE**

[![NuGet](https://img.shields.io/nuget/v/dymaptic.GeoBlazor.Core.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/dymaptic.GeoBlazor.Core/)
[![Downloads](https://img.shields.io/nuget/dt/dymaptic.GeoBlazor.Core?logo=nuget&label=downloads)](https://www.nuget.org/stats/packages/dymaptic.GeoBlazor.Core?groupby=Version)

**PRO**

[![NuGet](https://img.shields.io/nuget/v/dymaptic.GeoBlazor.Pro.svg?logo=nuget&logoColor=white)](https://www.nuget.org/packages/dymaptic.GeoBlazor.Pro/)
[![Downloads](https://img.shields.io/nuget/dt/dymaptic.GeoBlazor.Pro?logo=nuget&label=downloads)](https://www.nuget.org/stats/packages/dymaptic.GeoBlazor.Pro?groupby=Version)

[![Discord](https://img.shields.io/discord/1027907220949717033?color=%235865F2&label=chat&logo=discord&logoColor=white)](https://discord.gg/hcmbPzn4VW)

## ✨ Key Features

- **Pure C# Development**: Access the complete ArcGIS Maps SDK without writing a single line of JavaScript
- **Rich Component Library**: Includes maps, layers, widgets, geometries, and more
- **Interactive Maps**: Build responsive, interactive maps with minimal code
- **Flexible Architecture**: Works with Blazor Server, WebAssembly, and Hybrid MAUI apps
- **Enterprise-Ready**: Supports [ArcGIS Enterprise](https://docs.geoblazor.com/pages/authentication.html) for organizations with internal GIS infrastructure

## 🚀 Quick Links

- [Home Page](https://www.geoblazor.com)
- [Live Demo Site](https://samples.geoblazor.com)
- [Documentation](https://docs.geoblazor.com)
- [GitHub Repository](https://github.com/dymaptic/GeoBlazor)
- [Join our Discord Server](https://discord.gg/hcmbPzn4VW)

<p align="center">
  <img src="https://docs.geoblazor.com/assets/images/webmap.png" alt="GeoBlazor Map Example" width="800">
</p>

## 🧰 Installation

```bash
    dotnet add package dymaptic.GeoBlazor.Core
```

Or for the Pro version with additional features:

```bash
    dotnet add package dymaptic.GeoBlazor.Pro
```

> **Note:** *.NET 9 can cause __very slow__ build times due to its new static asset compression. If you need faster builds, we recommend staying on .NET 8 for now, and using a global.json file to pin your SDK build version to .NET 8. See our [open request for a fix here](https://github.com/dotnet/aspnetcore/issues/59014).*
> 
> *If you decide to stay with .NET 9, we suggest adding the following line to your `csproj` file to disable the new compression feature:*
> 
> ```xml
>    <PropertyGroup>
>        <CompressionEnabled Condition="$(Configuration) != 'RELEASE'">false</CompressionEnabled>
>    </PropertyGroup>
> ```

## 🏁 Getting Started

(from https://docs.geoblazor.com/pages/gettingStarted.html)

1. Create a new Blazor Web App, Blazor Server, Blazor Wasm, or Blazor Hybrid (MAUI) project.

2. Add a `PackageReference` to the latest version of the `dymaptic.GeoBlazor.Core` or `dymaptic.GeoBlazor.Pro` ([pro is a paid version with more features](pro)) package via your IDE's Nuget Package Manager or from the command line with `dotnet add package dymaptic.GeoBlazor.Core` (or `dotnet add package dymaptic.GeoBlazor.Pro`). For Blazor Web Apps supporting WebAssembly, add this reference to the `.Client` WebAssembly project, or a Razor Class Library where you intend to write your mapping Razor components.

3. Get an API Key from the [ArcGIS Location Platform](https://location.arcgis.com/). Place this in your
   `appsettings.json`, `secrets.json` (user secrets), or `environment variables`.:

   ```json
   {
       "ArcGISApiKey": "YourArcGISApiKey"
   }
   ```

4. Register at [licensing.dymaptic.com](https://licensing.dymaptic.com) for a free GeoBlazor Core Registration key.
   Add the key to `appsettings.json`:

   ```json
       {
           "ArcGISApiKey": "YourArcGISApiKey",
           "GeoBlazor": {
               "RegistrationKey": "YourGeoBlazorRegistrationKey"
           }
       }
   ```

5. In the root file that defines your html (`App.razor` for Blazor Web Apps, `_Layout.cshtml` for older Blazor Server apps, and `index.html` only for standalone Blazor WebAssembly apps), add the following to the `<head>` section:

   ```html
   <link href="_content/dymaptic.GeoBlazor.Core"/>
   <link href="_content/dymaptic.GeoBlazor.Core/assets/esri/themes/light/main.css" rel="stylesheet" />
   <link href="YourProject.styles.css" rel="stylesheet" />
   ```
   The `YourProject.styles.css` is the default stylesheet for your project, this line should already be present in your template, but is important for GeoBlazor to function correctly.
   For dark mode, replace `assets/esri/themes/light/main.css` with `assets/esri/themes/dark/main.css`.

   Starting in .NET 9, there is also a new static asset compression feature that uses an `Assets` dictionary. If you see
   this pattern, follow the same pattern for GeoBlazor links:

   ```html
   <link href="@Assets["_content/dymaptic.GeoBlazor.Core"]"/>
   <link href="@Assets["_content/dymaptic.GeoBlazor.Pro"]" />
   <link href="@Assets["_content/dymaptic.GeoBlazor.Core/assets/esri/themes/light/main.css"]" rel="stylesheet" />
   <link href="@Assets["YourProject.styles.css"]" rel="stylesheet" />
   ```

6. In `_Imports.razor` (for both Server and Client projects, if applicable), add the GeoBlazor namespaces:

   ```csharp
   @using dymaptic.GeoBlazor.Core
   @using dymaptic.GeoBlazor.Core.Attributes
   @using dymaptic.GeoBlazor.Core.Components
   @using dymaptic.GeoBlazor.Core.Components.Geometries
   @using dymaptic.GeoBlazor.Core.Components.Layers
   @using dymaptic.GeoBlazor.Core.Components.Popups
   @using dymaptic.GeoBlazor.Core.Components.Renderers
   @using dymaptic.GeoBlazor.Core.Components.Symbols
   @using dymaptic.GeoBlazor.Core.Components.Views
   @using dymaptic.GeoBlazor.Core.Components.Widgets
   @using dymaptic.GeoBlazor.Core.Enums
   @using dymaptic.GeoBlazor.Core.Events
   @using dymaptic.GeoBlazor.Core.Exceptions
   @using dymaptic.GeoBlazor.Core.Extensions
   @using dymaptic.GeoBlazor.Core.Functions
   @using dymaptic.GeoBlazor.Core.Interfaces
   @using dymaptic.GeoBlazor.Core.Model
   @using dymaptic.GeoBlazor.Core.Options
   @using dymaptic.GeoBlazor.Core.Results
   ```

7. In `Program.cs` (for both Server and Client projects, if applicable), register the GeoBlazor services:

   ```csharp
   builder.Services.AddGeoBlazor(builder.Configuration);
   ```
8. GeoBlazor requires Interactive Server or WebAssembly rendering enabled when using the modern `Blazor Web App` templates. Verify that the following lines are present in your `Program.cs`.
   (This is not relevant if you are using the older `Blazor Server` template, and does not apply to WebAssembly projects).

   ```csharp
   // Server
   builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();

   // or WebAssembly
   builder.Services.AddRazorComponents
       .AddInteractiveWebAssemblyComponents();
   
   // or both
   builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents()
       .AddInteractiveWebAssemblyComponents();
   ```
   
   and in the lower portion of the file:

   ```csharp
   // Server
   app.MapRazorComponents<App>()
       .AddInteractiveServerRenderMode();

   // or WebAssembly
   app.MapRazorComponents<App>()
       .AddInteractiveWebAssemblyRenderMode()
       .AddAdditionalAssemblies(typeof(Counter).Assembly);
   
   // or both
   app.MapRazorComponents<App>()
       .AddInteractiveServerRenderMode()
       .AddInteractiveWebAssemblyRenderMode()
       .AddAdditionalAssemblies(typeof(Counter).Assembly);
   ```
9. Create a Razor Component page with a map. Again for Blazor Web Apps, be sure that the `@rendermode` is defined at the 
   page or app level (line 2 of the example below). This should be `InteractiveServer` for Blazor Server, 
   `InteractiveWebAssembly` for Blazor WebAssembly, or `InteractiveAuto` for the automatic switching between modes. 
   [Learn more about Blazor render modes](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes).
   
   ```html
   @page "/map"
   @rendermode InteractiveServer

   <MapView Longitude="-118.805" Latitude="34.027" Zoom="11" Style="height: 400px; width: 100%;"> 
       <WebMap>
           <PortalItem PortalItemId="4a6cb60ebbe3483a805999d481c2daa5" />
       </WebMap>
       <ScaleBarWidget Position="OverlayPosition.BottomLeft" />
   </MapView>
   ```

10. Run your application and see your map!

For complete documentation, please visit [https://docs.geoblazor.com](https://docs.geoblazor.com)

## 🔄 Versions

GeoBlazor comes in two editions:

- **GeoBlazor Core** - Free, open-source edition with essential mapping capabilities
- **[GeoBlazor Pro](https://docs.geoblazor.com/pages/pro.html)** - Commercial edition with advanced features, 3D support, and priority support

Check out our [features comparison](https://docs.geoblazor.com/pages/features.html) to see which edition is right for you.

## 📝 License

GeoBlazor Core is licensed under the [MIT License](https://docs.geoblazor.com/pages/coreLicense.html).

GeoBlazor Pro is licensed under a [Commercial License](https://docs.geoblazor.com/pages/license.html) with a yearly subscription fee.


