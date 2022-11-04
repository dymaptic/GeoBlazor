---
layout: default
title: MapPoint
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## MapPoint Class

This is another representation of [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that should be used to create [MapPath](dymaptic.GeoBlazor.Core.Objects.MapPath.html 'dymaptic.GeoBlazor.Core.Objects.MapPath')s.

```csharp
public class MapPoint : System.Collections.Generic.List<double>,
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.MapPoint>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') &#129106; MapPoint

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[MapPoint](dymaptic.GeoBlazor.Core.Objects.MapPoint.html 'dymaptic.GeoBlazor.Core.Objects.MapPoint')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.MapPoint.MapPoint(double[])'></a>

## MapPoint(double[]) Constructor

Create a new point from a parameter list of numbers.

```csharp
public MapPoint(params double[] p);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapPoint.MapPoint(double[]).p'></a>

`p` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Objects.MapPoint.MapPoint(System.Collections.Generic.IEnumerable_double_)'></a>

## MapPoint(IEnumerable<double>) Constructor

Create a new point from a collection of numbers.

```csharp
public MapPoint(System.Collections.Generic.IEnumerable<double> p);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapPoint.MapPoint(System.Collections.Generic.IEnumerable_double_).p'></a>

`p` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Objects.MapPoint.Copy()'></a>

## MapPoint.Copy() Method

Clones and returns the copy.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapPoint Copy();
```

#### Returns
[MapPoint](dymaptic.GeoBlazor.Core.Objects.MapPoint.html 'dymaptic.GeoBlazor.Core.Objects.MapPoint')

<a name='dymaptic.GeoBlazor.Core.Objects.MapPoint.Equals(dymaptic.GeoBlazor.Core.Objects.MapPoint)'></a>

## MapPoint.Equals(MapPoint) Method

Custom equality check.

```csharp
public bool Equals(dymaptic.GeoBlazor.Core.Objects.MapPoint? other);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MapPoint.Equals(dymaptic.GeoBlazor.Core.Objects.MapPoint).other'></a>

`other` [MapPoint](dymaptic.GeoBlazor.Core.Objects.MapPoint.html 'dymaptic.GeoBlazor.Core.Objects.MapPoint')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
