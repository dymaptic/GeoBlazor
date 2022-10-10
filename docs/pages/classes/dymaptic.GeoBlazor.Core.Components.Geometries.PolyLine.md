---
layout: default
title: PolyLine
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## PolyLine Class

A polyline contains an array of paths and spatialReference. Each path is represented as an array of points. A polyline also has boolean-valued hasM and hasZ properties.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">ArcGIS JS API</a>

```csharp
public class PolyLine : dymaptic.GeoBlazor.Core.Components.Geometries.Geometry
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry') &#129106; PolyLine
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Paths'></a>

## PolyLine.Paths Property

An array of [dymaptic.GeoBlazor.Core.Objects.MapPath](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Objects.MapPath 'dymaptic.GeoBlazor.Core.Objects.MapPath') paths, or line segments, that make up the polyline.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapPath[] Paths { get; set; }
```

#### Property Value
[dymaptic.GeoBlazor.Core.Objects.MapPath](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Objects.MapPath 'dymaptic.GeoBlazor.Core.Objects.MapPath')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Type'></a>

## PolyLine.Type Property

The Geometry "type", used internally to render.

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
