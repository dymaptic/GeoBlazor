<style>
   #geoblazor-logo { 
      background-color: #5D2E8E; 
      padding: 1rem; 
      border-radius: 1rem; 
   }

   #pro-link {
      background-color: #d6d6d6;
      padding: 1rem;
      border-radius: 1rem;
      width: 300px;
   }
</style>

<p style="text-align: center;">
  <img id="geoblazor-logo" src="./gb_white_text_300px.png" alt="GeoBlazor" width="300">
</p>

<p style="text-align: center;">
  <b>The premier mapping solution for Asp.NET Core Blazor applications.</b>
</p>

GeoBlazor brings the power of the ArcGIS Maps SDK for JavaScript into your Blazor applications with 100% C# code - no JavaScript required. Create beautiful, interactive maps with industry-leading geospatial capabilities while maintaining a pure .NET development experience.

<p style="text-align: center;">
   <em>
      <a href="https://www.nuget.org/packages/dymaptic.GeoBlazor.Pro">
         <img id="pro-link" alt="GeoBlazor Pro" src="./Go-GeoBlazor-Pro.png" />
      </a>
   </em>
</p>

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

## 🏁 Getting Started

(from https://docs.geoblazor.com/pages/gettingStarted.html)

1. Create a new Blazor Web App (.NET 8), Blazor Server, Blazor Wasm, or Blazor Hybrid (MAUI) project.

2. Add a `PackageReference` to the latest version of the `dymaptic.GeoBlazor.Core` package via your IDE's Nuget Package
   Manager or `dotnet add package dymaptic.GeoBlazor.Core`.

3. Get an API Key from the [ArcGIS Portal](https://developers.arcgis.com/documentation/security-and-authentication/api-key-authentication/). For Blazor Server, place it in your
   appsettings.json:

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

5. In the root file that defines your html (`_Layout.cshtml`, `index.html`, or `App.razor`), add the following to the `<head>` section:

    ```html
    <link href="_content/dymaptic.GeoBlazor.Core"/>
    <link href="_content/dymaptic.GeoBlazor.Core/assets/esri/themes/light/main.css" rel="stylesheet" />
    <link href="YourProject.styles.css" rel="stylesheet" />
    ```

6. In `_Imports.razor`, add the GeoBlazor namespaces:

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

7. In `Program.cs`, register the GeoBlazor services:

   ```csharp
   builder.Services.AddGeoBlazor(builder.Configuration);
   ```

8. Create a Razor Component page with a map:

   ```html
   @page "/"

   <MapView Longitude="-118.805" Latitude="34.027" Zoom="11" Style="height: 400px; width: 100%;"> 
       <WebMap>
           <PortalItem Id="4a6cb60ebbe3483a805999d481c2daa5" />
       </WebMap>
       <ScaleBarWidget Position="OverlayPosition.BottomLeft" />
   </MapView>
   ```

8. Run your application and see your map!

For complete documentation, please visit [https://docs.geoblazor.com](https://docs.geoblazor.com)

## 🔄 Versions

GeoBlazor comes in two editions:

- **GeoBlazor Core** - Free, open-source edition with essential mapping capabilities
- **[GeoBlazor Pro](https://docs.geoblazor.com/pages/pro.html)** - Commercial edition with advanced features, 3D support, and priority support

Check out our [features comparison](https://docs.geoblazor.com/pages/features.html) to see which edition is right for you.

## 📝 License

GeoBlazor Core is licensed under the [MIT License](https://docs.geoblazor.com/pages/coreLicense.html).

GeoBlazor Pro is licensed under a [Commercial License](https://docs.geoblazor.com/pages/license.html) with a yearly subscription fee.


