---
layout: default
title: Polygon
parent: Geometries
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## Polygon Class

A polygon contains an array of rings and a spatialReference. Each ring is represented as an array of points. The first and last points of a ring must be the same. A polygon also has boolean-valued hasM and hasZ fields.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">ArcGIS JS API</a>

```csharp
public class Polygon : dymaptic.GeoBlazor.Core.Components.Geometries.Geometry
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry') &#129106; Polygon
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Rings'></a>

## Polygon.Rings Property

An array of [dymaptic.GeoBlazor.Core.Objects.MapPath](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Objects.MapPath 'dymaptic.GeoBlazor.Core.Objects.MapPath') rings.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapPath[] Rings { get; set; }
```

#### Property Value
[dymaptic.GeoBlazor.Core.Objects.MapPath](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Objects.MapPath 'dymaptic.GeoBlazor.Core.Objects.MapPath')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Type'></a>

## Polygon.Type Property

The Geometry "type", used internally to render.

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
