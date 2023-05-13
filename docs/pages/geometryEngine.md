---
layout: page
title: "Geometry Engine"
nav_order: 5
---

# Geometry Engine

The `GeometryEngine` is an injectable class that can be used to perform many common operations on geometries.
Unlike most GeoBlazor components, the GeometryEngine is not dependent on the `MapView`, but can be used as a standalone service.

In addition to the methods in the ArcGIS Maps SDK for JavaScript [geometryEngine](https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html),
GeoBlazor has moved all calculation methods from the `Geometry` classes themselves to the `GeometryEngine`. This allows geometries
to be treated as more pure data objects. Below is a list of methods that have been moved to the `GeometryEngine` from ArcGIS
geometry classes.

| ArcGIS geometry class | ArcGIS method | GeoBlazor method                   |
|-----------------------|---------------|------------------------------------|
| `extent`              | `centerAt`    | `GeometryEngine.CenterExtentAt`    |
| `extent`              | `contains`    | `GeometryEngine.Within`            |
| `extent`              | `expand`      | `GeometryEngine.Expand`            |
| `extent`              | `fromJSON`    | `GeometryEngine.FromArcGisJson`    |
| `extent`              | `normalize`   | `GeometryEngine.NormalizeExtent`   |
| `extent`              | `offset`      | `GeometryEngine.OffsetExtent`      |
| `extent`              | `toJSON`      | `GeometryEngine.ToArcGisJson`      |
| `extent`              | `union`       | `GeometryEngine.Union`             |
| `point`               | `distance`    | `GeometryEngine.Distance`          |
| `point`               | `equals`      | `GeometryEngine.EqualTo`           |
| `point`               | `fromJSON`    | `GeometryEngine.FromArcGisJson`    |
| `point`               | `normalize`   | `GeometryEngine.NormalizePoint`    |
| `point`               | `toJSON`      | `GeometryEngine.ToArcGisJson`      |
| `polyline`            | `addPath`     | `GeometryEngine.AddPath`           |
| `polyline`            | `fromJSON`    | `GeometryEngine.FromArcGisJson`    |
| `polyline`            | `getPoint`    | `GeometryEngine.GetPoint`          |
| `polyline`            | `insertPoint` | `GeometryEngine.InsertPoint`       |
| `polyline`            | `removePath`  | `GeometryEngine.RemovePath`        |
| `polyline`            | `removePoint` | `GeometryEngine.RemovePoint`       |
| `polyline`            | `setPoint`    | `GeometryEngine.SetPoint`          |
| `polyline`            | `toJSON`      | `GeometryEngine.ToArcGisJson`      |
| `polygon`             | `addRing`     | `GeometryEngine.AddRing`           |
| `polygon`             | `contains`    | `GeometryEngine.Within`            |
| `polygon`             | `fromExtent`  | `GeometryEngine.PolygonFromExtent` |
| `polygon`             | `fromJSON`    | `GeometryEngine.FromArcGisJson`    |
| `polygon`             | `getPoint`    | `GeometryEngine.GetPoint`          |
| `polygon`             | `insertPoint` | `GeometryEngine.InsertPoint`       |
| `polygon`             | `isClockwise` | `GeometryEngine.IsClockwise`       |
| `polygon`             | `removePoint` | `GeometryEngine.RemovePoint`       |
| `polygon`             | `removeRing`  | `GeometryEngine.RemoveRing`        |
| `polygon`             | `setPoint`    | `GeometryEngine.SetPoint`          |
| `polygon`             | `toJSON`      | `GeometryEngine.ToArcGisJson`      |

`Equals` and `Clone` methods are still available directly on each Geometry class, in addition to
`GeometryEngine.Clone` and `GeometryEngine.EqualTo`. For a full list of GeometryEngine methods, see the
[GeometryEngine Class Documentation Page](/pages/classes/dymaptic.GeoBlazor.Core.Model.GeometryEngine.html).
