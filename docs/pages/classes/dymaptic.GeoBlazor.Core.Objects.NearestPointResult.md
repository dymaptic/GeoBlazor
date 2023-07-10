---
layout: default
title: NearestPointResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## NearestPointResult Class

Object returned from the nearestCoordinate(), nearestVertex(), and nearestVertices() methods of  
[GeometryEngine](dymaptic.GeoBlazor.Core.Model.GeometryEngine.html 'dymaptic.GeoBlazor.Core.Model.GeometryEngine').

```csharp
public class NearestPointResult
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; NearestPointResult
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.NearestPointResult.Coordinate'></a>

## NearestPointResult.Coordinate Property

A vertex within the specified distance of the search.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point Coordinate { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Objects.NearestPointResult.Distance'></a>

## NearestPointResult.Distance Property

The distance from the inputPoint in the units of the view's spatial reference.

```csharp
public double Distance { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.NearestPointResult.IsEmpty'></a>

## NearestPointResult.IsEmpty Property

Indicates if it is an empty geometry.

```csharp
public bool IsEmpty { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.NearestPointResult.VertexIndex'></a>

## NearestPointResult.VertexIndex Property

The index of the vertex within the geometry's rings or paths.

```csharp
public int VertexIndex { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
