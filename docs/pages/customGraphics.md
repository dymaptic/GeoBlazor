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
iterating through a C# list of `Point`s and creating `Graphics` in Razor markup.

```html
<MapView @ref="_view" class="map-view" OnMapRendered="OnMapRendered">
    <Extent Xmin="-41525513" Ymin="4969181" Xmax="-36687355" Ymax="9024624">
        <SpatialReference Wkid="3857" />
    </Extent>
    <Map ArcGISDefaultBasemap="arcgis-topographic">
        <GraphicsLayer>
            @foreach (Point graphicPoint in _graphicPoints.Count)
            {
                <Graphic>
                    <Point Longitude="graphicPoint.Longitude" Latitude="graphicPoint.Latitude" />
                    <SimpleMarkerSymbol Color="@(new MapColor("red"))" Size="6">
                        <Outline Color="@(new MapColor("white"))" />
                    </SimpleMarkerSymbol>
                </Graphic>
            }
        </GraphicsLayer>
    </Map>
</MapView>
```

## Defining Graphics in C# Code

Both `MapView` and `GraphicsLayer` support programmatically adding graphics after the map view is rendered.

1. `GraphicsLayer.Add(graphic)` and `GraphicsLayer.Add(graphics)` allows you to add single or multiple graphics to the layer.
```csharp
await graphicsLayer.Add(new Graphic
{
    Geometry = new Point
    {
        Longitude = -118.80500,
        Latitude = 34.02700
    },
    Symbol = new SimpleMarkerSymbol
    {
        Color = new MapColor("red"),
        Size = 6,
        Outline = new SimpleLineSymbol
        {
            Color = new MapColor("white")
        }
    }
});
```

2. `MapView.AddGraphic(graphic)` and `MapView.AddGraphics(graphics)` allows you to add single or multiple graphics to the map view.
```csharp
await mapView.AddGraphic(new Graphic
{
    Geometry = new Point
    {
        Longitude = -118.80500,
        Latitude = 34.02700
    },
    Symbol = new SimpleMarkerSymbol
    {
        Color = new MapColor("red"),
        Size = 6,
        Outline = new SimpleLineSymbol
        {
            Color = new MapColor("white")
        }
    }
});
```

Both classes also support `Remove` and `Clear` methods to remove or clear all graphics from the layer.

Note that while you can define `Graphics` in a `FeatureLayer` via Razor Component markup, the `FeatureLayer` does not support
altering the graphics collection (aka `Source`) after the map is rendered.

## Altering a Rendered Graphic

Once a graphic is rendered, you can alter its `Geometry`, `Symbol`, `Attributes`, and `PopupTemplate` properties using `Set` methods.
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
await graphic.SetAttributes(new Dictionary<string, object>
{
    { "name", "My Graphic" }
});
await graphic.SetPopupTemplate(new PopupTemplate
{
    Title = "My Graphic",
    Content = "This is my graphic."
});
```