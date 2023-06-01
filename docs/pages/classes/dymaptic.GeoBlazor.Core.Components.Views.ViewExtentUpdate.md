---
layout: default
title: ViewExtentUpdate
parent: Classes
---
---
layout: default
title: ViewExtentUpdate
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Views](index.html#dymaptic.GeoBlazor.Core.Components.Views 'dymaptic.GeoBlazor.Core.Components.Views')

## ViewExtentUpdate Class

A class to represent all the parameters that make up the extent of the map view.

```csharp
public class ViewExtentUpdate :
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ViewExtentUpdate

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ViewExtentUpdate](dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.html 'dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_)'></a>

## ViewExtentUpdate(Extent, Point, double, double, Nullable<double>, Nullable<double>) Constructor

A class to represent all the parameters that make up the extent of the map view.

```csharp
public ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent Extent, dymaptic.GeoBlazor.Core.Components.Geometries.Point? Center, double Scale, double Zoom, System.Nullable<double> Rotation=null, System.Nullable<double> Tilt=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).Extent'></a>

`Extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

The [Extent](dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.html#dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Extent 'dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Extent') of the view.

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).Center'></a>

`Center` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that represents the center of the view.

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).Scale'></a>

`Scale` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The scale of the view.

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).Zoom'></a>

`Zoom` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The zoom level of the view.

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).Rotation'></a>

`Rotation` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The rotation of the view.

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.ViewExtentUpdate(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).Tilt'></a>

`Tilt` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The tilt of the 3d view camera.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Center'></a>

## ViewExtentUpdate.Center Property

The [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') that represents the center of the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point? Center { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Extent'></a>

## ViewExtentUpdate.Extent Property

The [Extent](dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.html#dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Extent 'dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Extent') of the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent Extent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Rotation'></a>

## ViewExtentUpdate.Rotation Property

The rotation of the view.

```csharp
public System.Nullable<double> Rotation { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Scale'></a>

## ViewExtentUpdate.Scale Property

The scale of the view.

```csharp
public double Scale { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Tilt'></a>

## ViewExtentUpdate.Tilt Property

The tilt of the 3d view camera.

```csharp
public System.Nullable<double> Tilt { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.ViewExtentUpdate.Zoom'></a>

## ViewExtentUpdate.Zoom Property

The zoom level of the view.

```csharp
public double Zoom { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

