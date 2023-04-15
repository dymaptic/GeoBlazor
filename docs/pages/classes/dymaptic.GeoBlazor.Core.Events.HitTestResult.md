---
layout: default
title: HitTestResult
parent: Classes
---
---
layout: default
title: HitTestResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## HitTestResult Class

Object specification for the result of the MapView.HitTest method.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#HitTestResult">  
    ArcGIS  
    JS API  
</a>

```csharp
public class HitTestResult :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.HitTestResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HitTestResult

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[HitTestResult](dymaptic.GeoBlazor.Core.Events.HitTestResult.html 'dymaptic.GeoBlazor.Core.Events.HitTestResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.HitTestResult.HitTestResult(dymaptic.GeoBlazor.Core.Events.ViewHit[],dymaptic.GeoBlazor.Core.Events.ScreenPoint)'></a>

## HitTestResult(ViewHit[], ScreenPoint) Constructor

Object specification for the result of the MapView.HitTest method.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#HitTestResult">  
    ArcGIS  
    JS API  
</a>

```csharp
public HitTestResult(dymaptic.GeoBlazor.Core.Events.ViewHit[] Results, dymaptic.GeoBlazor.Core.Events.ScreenPoint ScreenPoint);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.HitTestResult.HitTestResult(dymaptic.GeoBlazor.Core.Events.ViewHit[],dymaptic.GeoBlazor.Core.Events.ScreenPoint).Results'></a>

`Results` [ViewHit](dymaptic.GeoBlazor.Core.Events.ViewHit.html 'dymaptic.GeoBlazor.Core.Events.ViewHit')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

An array of result objects returned from the hitTest(). Results are returned when the location of the input screen  
coordinates intersects a Graphic or media element in the view.

<a name='dymaptic.GeoBlazor.Core.Events.HitTestResult.HitTestResult(dymaptic.GeoBlazor.Core.Events.ViewHit[],dymaptic.GeoBlazor.Core.Events.ScreenPoint).ScreenPoint'></a>

`ScreenPoint` [ScreenPoint](dymaptic.GeoBlazor.Core.Events.ScreenPoint.html 'dymaptic.GeoBlazor.Core.Events.ScreenPoint')

The screen coordinates (or native mouse event) of the click on the view.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.HitTestResult.Ground'></a>

## HitTestResult.Ground Property

Ground intersection result, only applies to SceneViews. The ground hit result will always be returned, even if the  
ground was excluded from the hitTest.

```csharp
public dymaptic.GeoBlazor.Core.Events.GroundIntersectionResult? Ground { get; set; }
```

#### Property Value
[GroundIntersectionResult](dymaptic.GeoBlazor.Core.Events.GroundIntersectionResult.html 'dymaptic.GeoBlazor.Core.Events.GroundIntersectionResult')

<a name='dymaptic.GeoBlazor.Core.Events.HitTestResult.Results'></a>

## HitTestResult.Results Property

An array of result objects returned from the hitTest(). Results are returned when the location of the input screen  
coordinates intersects a Graphic or media element in the view.

```csharp
public dymaptic.GeoBlazor.Core.Events.ViewHit[] Results { get; set; }
```

#### Property Value
[ViewHit](dymaptic.GeoBlazor.Core.Events.ViewHit.html 'dymaptic.GeoBlazor.Core.Events.ViewHit')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Events.HitTestResult.ScreenPoint'></a>

## HitTestResult.ScreenPoint Property

The screen coordinates (or native mouse event) of the click on the view.

```csharp
public dymaptic.GeoBlazor.Core.Events.ScreenPoint ScreenPoint { get; set; }
```

#### Property Value
[ScreenPoint](dymaptic.GeoBlazor.Core.Events.ScreenPoint.html 'dymaptic.GeoBlazor.Core.Events.ScreenPoint')

