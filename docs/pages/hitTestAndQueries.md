---
layout: page
title: "Queries and Hit Tests"
nav_order: 5
---

# Queries and Hit Tests

GeoBlazor is continually adding new interactive features to the SDK. Queries are a common GIS task, and one that we are 
actively working to support.

## Queries

### Querying a Layer from the MapView
Currently, you can run queries against a `MapView` or `SceneView` using the `QueryFeatures` method. This method 
takes in a `Symbol` and `PopupTemplate` which define how the queried features will be displayed on the map. See the
[Sql Query Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/SqlQuery.razor) for an example of how to use this method.

### Querying a LayerView
More advanced queries can be run against a `LayerView` using `CreateQuery` and `QueryObjectIds`. This allows you 
to decide what to do with the resulting objects. See the [Hit Tests Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/HitTests.razor) 
for an example where the query results are used to call `LayerView.Highlight()`.

```csharp
Query layerQuery = await _layerView.CreateQuery();
layerQuery.Where = $"YEAR = {newYear} AND NAME = '{newName}'";
int[] ids = await _layerView.QueryObjectIds(layerQuery);
_highlightHandle = await _layerView!.Highlight(ids);
```

## Hit Tests
When reacting to an [event handler](reactive.md), one common type of query is the `HitTest`, which determines which 
graphics intersect with a particular point on the map. This is useful for things like highlighting a feature when 
the user clicks on it. See the [Hit Tests Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/HitTests.razor)

```csharp
HitTestOptions options = new()
{
    IncludeByGeoBlazorId = new[] { _hurricaneLayer!.Id }
};
HitTestResult result = await _mapView.HitTest(pointerEvent, options);
Graphic? graphic = result.Results.OfType<GraphicHit>().FirstOrDefault()?.Graphic;
graphic?.Attributes.TryGetValue("OBJECTID", out object? objectId);
int? graphicId = objectId as int?;
```

_Note that while ArcGIS supports other types of `Hits` than Graphics, GeoBlazor currently only fully supports `GraphicHit`._
