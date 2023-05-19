---
layout: page
title: "Custom Graphics"
nav_order: 6
---

# Custom Graphics

While many `FeatureLayer` and `TileLayer` services come pre-loaded with images, GeoBlazor also supports custom
`Graphics` added to `FeatureLayer`s, `GraphicsLayer`s, and directly to the `MapView`.

## Defining Graphics in Razor Markup

The simplest way to define custom graphics is using the Razor Component markup syntax. Below is an example of
adding a single `Graphic` in Razor markup.

***Note that iterating through collections in markup creates very poor performance and may cause crashing, especially in
WebAssembly. See the C# example below for a better approach for multiple graphics.***

```html
<MapView @ref="_view" class="map-view" OnMapRendered="OnMapRendered">
    <Extent Xmin="-41525513" Ymin="4969181" Xmax="-36687355" Ymax="9024624">
        <SpatialReference Wkid="3857" />
    </Extent>
    <Map ArcGISDefaultBasemap="arcgis-topographic">
        <GraphicsLayer>
            <Graphic>
                <Point Longitude="@_graphicPoint.Longitude" Latitude="@_graphicPoint.Latitude" />
                <SimpleMarkerSymbol Color="@(new MapColor("red"))" Size="6">
                    <Outline Color="@(new MapColor("white"))" />
                </SimpleMarkerSymbol>
            </Graphic>
        </GraphicsLayer>
    </Map>
</MapView>
```

## Defining Graphics in C# Code

Both `MapView` and `GraphicsLayer` support programmatically adding graphics after the map view is rendered.

1. `GraphicsLayer.Add(graphic)` and `GraphicsLayer.Add(graphics)` allows you to add single or multiple graphics to the
   layer.

```csharp
await graphicsLayer.Add(new Graphic(new Point(-118.80500, 34.02700), new SimpleMarkerSymbol(new Outline(new MapColor("white"), new MapColor("red"))));
```

2. `MapView.AddGraphic(graphic)` and `MapView.AddGraphics(graphics)` allows you to add single or multiple graphics to
   the map view.

```csharp
await mapView.AddGraphic(new Graphic(new Point(-118.80500, 34.02700), new SimpleMarkerSymbol(new Outline(new MapColor("white"), new MapColor("red"))));
```

Both classes also support `Remove` and `Clear` methods to remove or clear all graphics from the layer.

Note that while you can define `Graphics` in a `FeatureLayer` via Razor Component markup, the `FeatureLayer` does not
support
altering the graphics collection (aka `Source`) after the map is rendered.

## Multiple Graphics in a Collection

For stable performance, *always* use `MapView.AddGraphics(IEnumerable&lt;Graphic&gt; graphics)`
or `GraphicsLayer.Add(IEnumerable&lt;Graphic&gt; graphics)` to add collections of graphics, and do not define them in
markup with a loop.

## Altering a Rendered Graphic

Once a graphic is rendered, you can alter its `Geometry`, `Symbol`, `Attributes`, and `PopupTemplate` properties
using `Set` methods.
This will cause the graphic to re-render on the map, without having to be added and removed.

```csharp
await graphic.SetGeometry(new Point
{
    Longitude = -118.80500,
    Latitude = 34.02700
});

await graphic.SetSymbol(new SimpleMarkerSymbol
{
    Color = new MapColor("red"),
    Size = 6,
    Outline = new SimpleLineSymbol
    {
        Color = new MapColor("white")
    }
});

await graphic.SetPopupTemplate(new PopupTemplate
{
    Title = "My Graphic",
    Content = "This is my graphic."
});
```

## Attributes

Graphic attributes are a key/value collection of data stored with the graphic. They can be displayed
using a `PopupTemplate` or used to filter the `FeatureLayer` or `GraphicsLayer` source. Changes to attributes
after first render should be achieved with the async methods on `AttributeDictionary`, `AddOrUpdate`, `Remove`, and `Clear`.

```csharp
<Graphic @ref="_graphic" Attributes="_attributes" />

@code {
    private Graphic? _graphic;
    private AttributesDictionary _attributes = new AttributesDictionary(
        new Dictionary<string, object>
        {
            { "Name", "My Graphic" },
            { "Description", "This is my graphic." }
        });

    private async Task ChangeAttributes()
    {
        await _attributes.AddOrUpdate("Name", "My New Graphic");
        // or
        await _graphic.Attributes.AddOrUpdate("Description", "This is my new graphic.");
    }
}
```