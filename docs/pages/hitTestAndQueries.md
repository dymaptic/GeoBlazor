---
layout: page
title: "Queries and Hit Tests"
nav_order: 8
---

# Queries and Hit Tests

GeoBlazor is continually adding new interactive features to the SDK. Queries are a common GIS task, and one that we are
actively working to support.

## Queries

### Querying a FeatureLayer

`FeatureLayer` supports the following query methods on hosted layers accessed with a Url or `PortalItem.Id`.
For each, you define a `Query`, `RelationshipQuery`, or `TopQuery` in code, and then pass it to the method.

- `QueryExtent` - returns an `Extent` of features that matches the `Query`
- `QueryFeatures` - returns a `FeatureSet` of features (graphics) that match the `Query`.
  See [Server Side Queries Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/ServerSideQueries.razor).
- `QueryFeatureCount` - returns the number of features that match the `Query`
- `QueryObjectIds` - returns an array of object ids that match the `Query`
- `QueryRelatedFeatures` - returns a `FeatureSet` of related features that match the `RelationshipQuery`.
  See [Query Related Features Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/QueryRelatedFeatures.razor).
- `QueryRelatedFeatureCount` - returns the number of related features that match the `RelationshipQuery`
- `QueryTopFeatures` - returns a `FeatureSet` of the features that match the `TopFeaturesQuery`.
  See [Query Top Features Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/QueryTopFeatures.razor).
- `QueryTopFeatureCount` - returns the number of the features that match the `TopFeaturesQuery`
- `QueryTopObjectIds` - returns an array of the top object ids that match the `TopFeaturesQuery`
- `QueryTopFeaturesExtent` - returns an `Extent` of the top features that match the `TopFeaturesQuery`

### Querying a LayerView

`FeatureLayerView` supports a lot of the same queries as `FeatureLayer`. The difference is that while layer queries run
against the hosted layer service,
layerView queries run against the rendered view.
See
the [Hit Tests Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/HitTests.razor)
for an example where the query results are used to call `LayerView.Highlight()`.

### Querying a Layer from the MapView

In an early prototype of GeoBlazor, we added a custom query method to `MapView` called `QueryFeatures`.
Unlike the methods on `FeatureLayer` and `FeatureLayerView`, this method does not return the results, but instead
automatically updates the display based on the inputs. It takes in a `Symbol` and `PopupTemplate` which define how
the queried features will be displayed on the map. See the
[Sql Query Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/SqlQuery.razor)
for an example of how to use this method.

```csharp
Query layerQuery = await _layerView.CreateQuery();
layerQuery.Where = $"YEAR = {newYear} AND NAME = '{newName}'";
int[] ids = await _layerView.QueryObjectIds(layerQuery);
_highlightHandle = await _layerView!.Highlight(ids);
```

## Hit Tests

When reacting to an [event handler](reactive.md), one common type of query is the `HitTest`, which determines which
graphics intersect with a particular point on the map. This is useful for things like highlighting a feature when
the user clicks on it. See
the [Hit Tests Sample Page](https://github.com/dymaptic/GeoBlazor/blob/main/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/HitTests.razor)

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

_Note that while ArcGIS supports other types of `Hits` than Graphics, GeoBlazor currently only fully
supports `GraphicHit`._
