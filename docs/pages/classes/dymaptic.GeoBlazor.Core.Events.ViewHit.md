---
layout: default
title: ViewHit
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## ViewHit Class

Object specification for the [Results](dymaptic.GeoBlazor.Core.Events.HitTestResult.html#dymaptic.GeoBlazor.Core.Events.HitTestResult.Results 'dymaptic.GeoBlazor.Core.Events.HitTestResult.Results').  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#ViewHit">ArcGIS JS API</a>

```csharp
public class ViewHit :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.ViewHit>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ViewHit

Derived  
&#8627; [GraphicHit](dymaptic.GeoBlazor.Core.Events.GraphicHit.html 'dymaptic.GeoBlazor.Core.Events.GraphicHit')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ViewHit](dymaptic.GeoBlazor.Core.Events.ViewHit.html 'dymaptic.GeoBlazor.Core.Events.ViewHit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.ViewHit.ViewHit(string,dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## ViewHit(string, Point) Constructor

Object specification for the [Results](dymaptic.GeoBlazor.Core.Events.HitTestResult.html#dymaptic.GeoBlazor.Core.Events.HitTestResult.Results 'dymaptic.GeoBlazor.Core.Events.HitTestResult.Results').  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#ViewHit">ArcGIS JS API</a>

```csharp
public ViewHit(string Type, dymaptic.GeoBlazor.Core.Components.Geometries.Point MapPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.ViewHit.ViewHit(string,dymaptic.GeoBlazor.Core.Components.Geometries.Point).Type'></a>

`Type` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The type of hit result. Currently only supporting "graphic".

<a name='dymaptic.GeoBlazor.Core.Events.ViewHit.ViewHit(string,dymaptic.GeoBlazor.Core.Components.Geometries.Point).MapPoint'></a>

`MapPoint` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

The point geometry in the spatial reference of the view corresponding with the input screen coordinates.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.ViewHit.MapPoint'></a>

## ViewHit.MapPoint Property

The point geometry in the spatial reference of the view corresponding with the input screen coordinates.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point MapPoint { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Events.ViewHit.Type'></a>

## ViewHit.Type Property

The type of hit result. Currently only supporting "graphic".

```csharp
public string Type { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
