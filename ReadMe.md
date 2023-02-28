# GeoBlazor

[Home Page](https://www.geoblazor.com)

[View the live demo site!](https://samples.geoblazor.com)

[Read the Docs](https://docs.geoblazor.com)

[Join our Discord Server!](https://discord.gg/hcmbPzn4VW)

## Build Requirements

For the Asp.NET projects, including the core library, you can run on the
latest [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)
or [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download).

For the Maui sample project, you need the latest Visual Studio 2022
and/or [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download).

If you have not installed node.js on your system, you will need to download and install it in order for the npm scripts
to run. Please [select
the appropriate installer for your system](https://nodejs.org/en/download/).

You will need to install Powershell 7 on your machine to run the powershell script as part of the build process.
-Complete installation instructions for Powershell [can be found here]
(https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell?view=powershell-7.2).

**Note** A reboot is required after installing the above components.

Because GeoBlazor uses an unsigned, local powershell script to copy files in the `Sample.Shared` project, you need to
allow unsigned scripts to be run in Powershell.
-The procedure to change the "execution policies" and set them to `RemoteSigned` are found here:
https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7.2#change-the-execution-policy

**Note** If you receive an unsigned error even after you set the above execution policy, try setting it again in the
older version of PowerShell (the one that comes with Windows).

On the first build, the Core project needs to download a large number of files from `npm` to `node_modules`, and then
copy them into `wwwroot/assets`. If this process fails, or you get an error on running the samples of "Cannot load
ArcGIS Assets", usually re-building the project will fix the errors.

## Projects

### dymaptic.GeoBlazor.Core

- The core logic library

### dymaptic.GeoBlazor.Core.Sample.Shared

- A razor class library for sample applications
- All sample pages are based on
  the [ArcGIS for Javascript API Tutorials](https://developers.arcgis.com/javascript/latest/).

### dymaptic.GeoBlazor.Core.Sample.Server

- Asp.NET Core Blazor Server application sample
- `dotnet run --project .\samples\dymaptic.GeoBlazor.Core.Sample.Server\dymaptic.GeoBlazor.Core.Sample.Server.csproj`
- Runs on kestrel or via IIS
- Serves pages via SignalR/Websockets
- Can be loaded with a `usersecrets` file to provide the ArcGIS Api Key.

### dymaptic.GeoBlazor.Core.Sample.Wasm

- `dotnet run --project .\samples\dymaptic.GeoBlazor.Core.Sample.Wasm\dymaptic.GeoBlazor.Core.Sample.Wasm.csproj`
- Runs Blazor in Web Assembly on the client browser
- No safe storage for API key, users must input an api key or sign in from the browser

### dymaptic.GeoBlazor.Core.Sample.Maui

- Cross-platform mobile and desktop application
- Should be run from Visual Studio Preview. Command Line support appears to be limited at this time.
- Android and Windows versions tested

### dymaptic.GeoBlazor.pro (not included in open source repo)

- Extended application features - coming soon!
- Please contact info@dymaptic.com to discuss licensing these advanced features!

This project wraps the [ArcGIS Javascript API](https://developers.arcgis.com/javascript/latest/) in a Blazor templating
framework.
It generates a nuget package that can be imported and consumed from any Blazor application, without directly interacting
with javascript.

In addition to "hiding" the javascript implementation, the goal is also to make a simple, component-based system for
declaring a map and view. For example:

```html
<MapView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 600px; width: 100%;">
    <Map ArcGISDefaultBasemap="arcgis-topographic">
        <GraphicsLayer>
            <Graphic>
                <Point Longitude="_longitude" Latitude="_latitude"/>
                <SimpleMarkerSymbol Color="@(new MapColor(226, 119, 40))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleMarkerSymbol>
            </Graphic>
            <Graphic>
                <PolyLine Paths="@_mapPaths"/>
                <SimpleLineSymbol Color="@(new MapColor(226, 119, 40))" Width="2"/>
            </Graphic>
            <Graphic>
                <Polygon Rings="@_mapRings"/>
                <SimpleFillSymbol Color="@(new MapColor(227, 139, 79, 0.8))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleFillSymbol>
                <Attributes Name="This is a Title" Description="And a Description"/>
                <PopupTemplate Title="{Name}" Content="{Description}"/>
            </Graphic>
        </GraphicsLayer>
    </Map>
</MapView>
```

for a 2D map with a default ArcGIS basemap, or

```html
<SceneView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 600px; width: 100%;" ZIndex="2000" Tilt="76">
    <Map Ground="world-elevation">
        <Basemap>
            <PortalItem Id="f35ef07c9ed24020aadd65c8a65d3754" />
        </Basemap>
        <GraphicsLayer>            <Graphic>
                <Point Longitude="_longitude" Latitude="_latitude"/>
                <SimpleMarkerSymbol Color="@(new MapColor(226, 119, 40))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleMarkerSymbol>
            </Graphic>
            <Graphic>
                <PolyLine Paths="@_mapPaths"/>
                <SimpleLineSymbol Color="@(new MapColor(226, 119, 40))" Width="2"/>
            </Graphic>
            <Graphic>
                <Polygon Rings="@_mapRings"/>
                <SimpleFillSymbol Color="@(new MapColor(227, 139, 79, 0.8))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleFillSymbol>
                <Attributes Name="This is a Title" Description="And a Description"/>
                <PopupTemplate Title="{Name}" Content="{Description}"/>
            </Graphic>
        </GraphicsLayer>
    </Map>
</SceneView>
```

for a 3D map with a basemap loaded from a `PortalId`.

