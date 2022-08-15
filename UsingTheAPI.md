# Using ArcGIS in Asp.NET Blazor – No JavaScript Required!

In my previous post, I showed how to call the ArcGIS JavaScript API using the `IJSRuntime` from Asp.NET Blazor.
Today, I'm happy to announce a free, open-source Nuget package for accessing ArcGIS directly in Blazor components, no JavaScript required!
To get started, create a new Blazor Server application, and add a `PackageReference` to the `dymaptic.Blazor.GIS.API.Core`
package (via your IDE's Nuget Package Manager or `dotnet add package dymaptic.Blazor.GIS.API.Core`).
Next, in `Pages/\_Layout.cshtml`, add the following to the head block of the html. Note the double @ symbols required,
since the symbol is a reserved character in Razor.

```html
    <link href="\_content/dymaptic.Blazor.GIS.API.Core"/>
    <script src="https://unpkg.com/@@esri/arcgis-rest-request@@3.0.0/dist/umd/request.umd.js"></script>
    <script src="https://unpkg.com/@@esri/arcgis-rest-auth@@3.0.0/dist/umd/auth.umd.js"></script>
    <script src="https://unpkg.com/@@esri/arcgis-rest-demographics@@3.0.0/dist/umd/demographics.umd.js"></script>
    <link href="https://js.arcgis.com/4.23/esri/themes/light/main.css" rel="stylesheet"/>
    <script src="https://js.arcgis.com/4.23/"></script>
```

Now, you will need to get an ArcGIS API Key from the [Developer Dashboard](https://developers.arcgis.com/dashboard/).
For security reasons, you should _not_ add this to any files that will be checked into version control.
I recommend adding a [User Secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows) file.
You can also use `appsettings.development.json`, but if you do, I recommend adding it to `.gitignore` before checking in code.

Here's what the JSON would look like in `secrets.json` or `appsettings.development.json`:

```json
{
    "ArcGISApiKey": "YOUR_API_KEY"
}
```

This will be picked up and added to your maps automatically by the Asp.NET dependency injection framework.
Next, let's add the following `@using` statements to `\_Imports.razor`, so that our pages and components have access to
the necessary package components.

```csharp
@using dymaptic.Blazor.GIS.API.Core.Components
@using dymaptic.Blazor.GIS.API.Core.Components.Geometries
@using dymaptic.Blazor.GIS.API.Core.Components.Layers
@using dymaptic.Blazor.GIS.API.Core.Components.Popups
@using dymaptic.Blazor.GIS.API.Core.Components.Symbols
@using dymaptic.Blazor.GIS.API.Core.Components.Views
@using dymaptic.Blazor.GIS.API.Core.Objects
```

That's it! Now you are ready to write your first ArcGIS Map View in Blazor. Add the following code to the bottom of `Pages/Index.razor`.

```html
<MapView Longitude="_longitude" Latitude="_latitude" Zoom="11" Style="height: 400px; width: 100%;">
    <Map ArcGISDefaultBasemap="arcgis-topographic">
        <GraphicsLayer>
            <Graphic>
                <Point Longitude="_longitude" Latitude="_latitude"/>
                <SimpleMarkerSymbol Color="@(new MapColor(226, 119, 40))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleMarkerSymbol>
            </Graphic>
            <Graphic>
                <PolyLine Paths="@(new[] { _mapPath })" />
                <SimpleLineSymbol Color="@(new MapColor(226, 119, 40))" Width="2"/>
            </Graphic>
            <Graphic>
                <Polygon Rings="@(new[] { _mapRings })" />
                <SimpleFillSymbol Color="@(new MapColor(227, 139, 79, 0.8))">
                    <Outline Color="@(new MapColor(255, 255, 255))" Width="1"/>
                </SimpleFillSymbol>
                <Attributes Name="This is a Title" Description="And a Description"/>
                <PopupTemplate Title="{Name}" StringContent="{Description}"/>
            </Graphic>
        </GraphicsLayer>
    </Map>
</MapView>
```

```csharp
@code
{
    private readonly double _latitude = 34.027; 
    private readonly double _longitude = -118.805;
  
    private readonly MapPath _mapPath = new(new MapPoint(-118.821527826096, 34.0139576938577),  
        new MapPoint(-118.814893761649, 34.0080602407843),
        new MapPoint(-118.808878330345, 34.0016642996246));
  
    private readonly MapPath _mapRings = new(new MapPoint(-118.818984489994, 34.0137559967283),
        new MapPoint(-118.806796597377, 34.0215816298725),
        new MapPoint(-118.791432890735, 34.0163883241613),
        new MapPoint(-118.79596686535, 34.008564864635),
        new MapPoint(-118.808558110679, 34.0035027131376));
}
```

Run the project, and you should see your new map directly in the blazor application!

<img src="sample1.png" width="600" />
