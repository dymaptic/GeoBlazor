---
layout: default
title: MapPath
parent: Classes
---
---
layout: default
title: MapPath
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## MapPath Class

Represents both [Paths](dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.html#dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Paths 'dymaptic.GeoBlazor.Core.Components.Geometries.PolyLine.Paths') and [Rings](dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.html#dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Rings 'dymaptic.GeoBlazor.Core.Components.Geometries.Polygon.Rings'), as a two-dimensional array of  
number coordinates.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html#paths">  
    ArcGIS  
    JS API  
</a>

```csharp
public class MapPath : System.Collections.Generic.List<dymaptic.GeoBlazor.Core.Objects.MapPoint>,
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.MapPath>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[MapPoint](dymaptic.GeoBlazor.Core.Objects.MapPoint.html 'dymaptic.GeoBlazor.Core.Objects.MapPoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') &#129106; MapPath

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.MapPath(dymaptic.GeoBlazor.Core.Objects.MapPoint[])'></a>

## MapPath(MapPoint[]) Constructor

Generate a new path or ring from a parameter list of points.

```csharp
public MapPath(params dymaptic.GeoBlazor.Core.Objects.MapPoint[] p);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.MapPath(dymaptic.GeoBlazor.Core.Objects.MapPoint[]).p'></a>

`p` [MapPoint](dymaptic.GeoBlazor.Core.Objects.MapPoint.html 'dymaptic.GeoBlazor.Core.Objects.MapPoint')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.MapPath(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Objects.MapPoint_)'></a>

## MapPath(IEnumerable<MapPoint>) Constructor

Generate a new path or ring from a collection of points.

```csharp
public MapPath(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Objects.MapPoint> p);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.MapPath(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Objects.MapPoint_).p'></a>

`p` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[MapPoint](dymaptic.GeoBlazor.Core.Objects.MapPoint.html 'dymaptic.GeoBlazor.Core.Objects.MapPoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.DeepCopy()'></a>

## MapPath.DeepCopy() Method

Clones a path and returns the new copy.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapPath DeepCopy();
```

#### Returns
[MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.Equals(dymaptic.GeoBlazor.Core.Objects.MapPath)'></a>

## MapPath.Equals(MapPath) Method

Custom equality check.

```csharp
public bool Equals(dymaptic.GeoBlazor.Core.Objects.MapPath? other);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.Equals(dymaptic.GeoBlazor.Core.Objects.MapPath).other'></a>

`other` [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.Equals(object)'></a>

## MapPath.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Objects.MapPath.GetHashCode()'></a>

## MapPath.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.

