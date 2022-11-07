---
layout: page
title: "Getting Started"
nav_order: 2
---
# Getting Started

<video style="width: 100%;" controls>
    <source src="../assets/videos/GeoBlazorDemo1_with_music_and_text.mp4" type="video/mp4">
    Your browser does not support the video tag.
</video>

1. Create a new Blazor Server, Blazor Wasm, or Blazor Hybrid (MAUI) project, using the templates provided in your IDE or
   the `dotnet` CLI.
2. add a `PackageReference` to the latest version of the `dymaptic.GeoBlazor.Core` package via your IDE's Nuget Package
   Manager or `dotnet add package dymaptic.GeoBlazor.Core`.
3. The ArcGIS API requires some form of authentication. The simplest is to use an API Key. Generate a key from the [ArcGIS Developer Dashboard](https://developers.arcgis.com/api-keys/) and place it in your appsettings.json, like this:

   ```json
   {
       "ArcGISApiKey": "yourKeyValue"
   }
   ```
   <div style="font-size: 0.8rem; font-style: italic; margin-bottom: 1rem;">
   Note: If you are using Blazor WASM, <span style="color:red;">be aware</span> that the API key will be exposed in the browser 
   (just like it would with Javascript). Even when using Blazor Server, the API key may be present in HTTP requests 
   visible to the user in the browsers dev tools, so you should probably take other steps like setting up referrer rules 
   in ArcGIS.
   </div>
   <div style="font-size: 0.8rem; font-style: italic">
   You can also set up an OAuth2 workflow, which is more secure as it does not expose a static API key, 
   but this is more complex. You can read about all the authentication options in [Authentication](authentication).
   </div>
4. In the root file that defines your html, add the following lines to the `<head>` section.
   This would be `_Layout.cshtml` for Blazor Server, or `index.html` for Blazor Wasm and Blazor Hybrid.

   ```html
   <link href="_content/dymaptic.GeoBlazor.Core"/>
   <link href="https://js.arcgis.com/4.24/esri/themes/light/main.css" rel="stylesheet"/>
   ```
5. In `_Imports.razor`, add the following lines, or add as needed to resolve code that you consume.

   ```csharp
   @using dymaptic.GeoBlazor.Core.Components
   @using dymaptic.GeoBlazor.Core.Components.Geometries
   @using dymaptic.GeoBlazor.Core.Components.Layers
   @using dymaptic.GeoBlazor.Core.Components.Popups
   @using dymaptic.GeoBlazor.Core.Components.Symbols
   @using dymaptic.GeoBlazor.Core.Components.Views
   @using dymaptic.GeoBlazor.Core.Objects
   ```
6. Create a new Razor Component in the `Pages` folder, or just use `Index.razor`. Add a `MapView`. Give it basic
   parameters to ensure that it can render.

   ```html
   @page "/"

   <MapView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 400px; width: 100%;"> 
   </MapView>
   ```
7. Within the `MapView`, define a `Map`. To load a pre-generated map from ArcGIS Online or a Portal, get the Portal Id
   of the map, and use the `WebMap` component.

   ```html
   <MapView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 400px; width: 100%;"> 
       <WebMap>
           <PortalItem Id="41281c51f9de45edaf1c8ed44bb10e30" />
       </WebMap>
   </MapView>
   ```
8. Add a Widget to the `MapView`, after the `WebMap`.

   ```html
   <MapView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 400px; width: 100%;"> 
       <WebMap>
           <PortalItem Id="41281c51f9de45edaf1c8ed44bb10e30" />
       </WebMap>
       <ScaleBarWidget Position="OverlayPosition.BottomLeft" />
   </MapView>
   ```
9. Run your application and make sure you can see your map!
   ![Web Map Sample](../assets/images/webmap.png)
