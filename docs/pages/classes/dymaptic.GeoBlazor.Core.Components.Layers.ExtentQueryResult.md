---
layout: default
title: ExtentQueryResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## ExtentQueryResult Class

The return type for [QueryExtent(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)').

```csharp
public class ExtentQueryResult :
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExtentQueryResult

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ExtentQueryResult](dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.html 'dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.ExtentQueryResult(int,dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## ExtentQueryResult(int, Extent) Constructor

The return type for [QueryExtent(Query, CancellationToken)](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html#dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query,System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.QueryExtent(dymaptic.GeoBlazor.Core.Objects.Query, System.Threading.CancellationToken)').

```csharp
public ExtentQueryResult(int Count, dymaptic.GeoBlazor.Core.Components.Geometries.Extent Extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.ExtentQueryResult(int,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).Count'></a>

`Count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The number of features that satisfy the input query.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.ExtentQueryResult(int,dymaptic.GeoBlazor.Core.Components.Geometries.Extent).Extent'></a>

`Extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The extent of features that satisfy the query.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.Count'></a>

## ExtentQueryResult.Count Property

The number of features that satisfy the input query.

```csharp
public int Count { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.ExtentQueryResult.Extent'></a>

## ExtentQueryResult.Extent Property

The extent of features that satisfy the query.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent Extent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')
