---
layout: page
title: "Managing View Extent"
nav_order: 4
---
# Managing View Extent

There are many ways to set and retrieve the extent of a view in GeoBlazor.

## Setting the extent in Razor Component Markup

The advantage of setting the extent in Razor markup is that it will be read
before the view is rendered.

1. You can set the `Extent` property directly inside the `MapView`. If the
   `SpatialReference` is not specified, it will default to the basemap's spatial reference.

```html
<MapView>
    <Extent XMin="-14092388.508390034"
            XMax="-8427487.468120558"
            YMin="2705131.7741284175"
            YMax="6452380.648779902">
        <SpatialReference Wkid="102100" />
    </Extent>
    <Map ArcGisDefaultBasemap="arcgis-topographic" />
</MapView>
```

2. You can also set the Center (Long/Lat) and Zoom or Scale parameters on `MapView` to define an extent.

```html
<MapView Longitude="-118.80500" Latitude="34.02700" Zoom="13">
    <Map ArcGisDefaultBasemap="arcgis-topographic" />
</MapView>
```

Setting either `Extent`'s or `MapView`'s parameters to a variable would allow one to alter the extent programmatically 
after rendering. However, it should be noted that if a user interacts with the view manually via drag, pinch-to-zoom, 
or the zoom controls, or any of the `MapView.Set` methods listed below are called, the Razor component parameters will 
be _disabled_ from controlling the extent until the view is re-rendered, such as by calling `mapView.Refresh()`.

## Setting the extent in C# code

Once the view is rendered, it may be necessary to change the view's extent in code.

1. `SetExtent` allows you to directly alter the current view extent.
```csharp
await mapView.SetExtent(new Extent
{
    XMin = -14092388.508390034,
    XMax = -8427487.468120558,
    YMin = 2705131.7741284175,
    YMax = 6452380.648779902,
    SpatialReference = new SpatialReference { Wkid = 102100 }
});
```

2. `GoTo(extent)` is similar to `SetExtent`, but it provides more animation.
```csharp
await mapView.GoTo(new Extent
{
    XMin = -14092388.508390034,
    XMax = -8427487.468120558,
    YMin = 2705131.7741284175,
    YMax = 6452380.648779902,
    SpatialReference = new SpatialReference { Wkid = 102100 }
});
```

3. `SetCenter` and `SetZoom` allow you to set the center and zoom level of the view.
```csharp
await mapView.SetCenter(new MapPoint(-118.80500, 34.02700));
await mapView.SetZoom(13);
```

As mentioned above, once these methods are called, the Razor component markup parameters will be ignore on further
page renders, until `mapView.Refresh()` is called or the entire view is re-loaded.