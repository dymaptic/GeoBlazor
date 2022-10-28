---
layout: page
title: "Getting Started"
nav_order: 2
---

# Getting Started

1. Create a new Blazor Server, Blazor Wasm, or Blazor Hybrid (MAUI) project, using the templates provided in your IDE or
   the `dotnet` CLI.
2. add a `PackageReference` to the latest version of the `dymaptic.GeoBlazor.Core` package via your IDE's Nuget Package 
   Manager or `dotnet add package dymaptic.GeoBlazor.Core`.
3. In the root file that defines your html, add the following lines to the `<head>` section. 
   This would be `_Layout.cshtml` for Blazor Server, or `index.html` for Blazor Wasm and Blazor Hybrid.

    ```html
    <link href="_content/dymaptic.GeoBlazor.Core"/>
    <link href="https://js.arcgis.com/4.24/esri/themes/light/main.css" rel="stylesheet"/>
    ```
    
    or (dark theme)
    
    ```html
    <link href="_content/dymaptic.GeoBlazor.Core"/>
    <link href="https://js.arcgis.com/4.24/esri/themes/dark/main.css" rel="stylesheet"/>
    ```

4. See [Authentication](authentication) to generate and load an API Token.
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
   ![Web Map Sample](assets/images/webmap.png)