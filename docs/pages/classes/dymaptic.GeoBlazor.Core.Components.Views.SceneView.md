---
layout: default
title: SceneView
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Views](index.html#dymaptic.GeoBlazor.Core.Components.Views 'dymaptic.GeoBlazor.Core.Components.Views')

## SceneView Class

A SceneView displays a 3D view of a Map or WebScene instance using WebGL. To render a map and its layers in 2D, see  
the documentation for MapView. For a general overview of views, see View.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">ArcGIS JS API</a>

```csharp
public class SceneView : dymaptic.GeoBlazor.Core.Components.Views.MapView
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') &#129106; SceneView

### Example
<a target="_blank" href="https://samples.geoblazor.com/web-scene">Sample - Web Scene</a>
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.Tilt'></a>

## SceneView.Tilt Property

The tilt of the camera in degrees with respect to the surface as projected down from the camera position.

```csharp
public System.Nullable<double> Tilt { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.ZIndex'></a>

## SceneView.ZIndex Property

The Z-Index (elevation) of the camera position over the view.

```csharp
public System.Nullable<double> ZIndex { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.GoTo(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_)'></a>

## SceneView.GoTo(IEnumerable<Graphic>) Method

Changes the view [dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') and redraws.

```csharp
public override System.Threading.Tasks.Task GoTo(System.Collections.Generic.IEnumerable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic> graphics);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.GoTo(System.Collections.Generic.IEnumerable_dymaptic.GeoBlazor.Core.Components.Layers.Graphic_).graphics'></a>

`graphics` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')s to zoom to.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_)'></a>

## SceneView.OnJavascriptExtentChanged(Extent, Point, double, double, Nullable<double>, Nullable<double>) Method

JS-Invokable method to return when the map view Extent changes.

```csharp
public override System.Threading.Tasks.Task OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent, dymaptic.GeoBlazor.Core.Components.Geometries.Point? center, double zoom, double scale, System.Nullable<double> rotation=null, System.Nullable<double> tilt=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).center'></a>

`center` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).zoom'></a>

`zoom` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).scale'></a>

`scale` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).rotation'></a>

`rotation` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.OnJavascriptExtentChanged(dymaptic.GeoBlazor.Core.Components.Geometries.Extent,dymaptic.GeoBlazor.Core.Components.Geometries.Point,double,double,System.Nullable_double_,System.Nullable_double_).tilt'></a>

`tilt` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetCenter(dymaptic.GeoBlazor.Core.Components.Geometries.Point)'></a>

## SceneView.SetCenter(Point) Method

Sets the center [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point') of the current view.

```csharp
public override System.Threading.Tasks.Task SetCenter(dymaptic.GeoBlazor.Core.Components.Geometries.Point point);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetCenter(dymaptic.GeoBlazor.Core.Components.Geometries.Point).point'></a>

`point` [Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetExtent(dymaptic.GeoBlazor.Core.Components.Geometries.Extent)'></a>

## SceneView.SetExtent(Extent) Method

Sets the [dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent 'dymaptic.GeoBlazor.Core.Components.Views.MapView.Extent') of the view.

```csharp
public override System.Threading.Tasks.Task SetExtent(dymaptic.GeoBlazor.Core.Components.Geometries.Extent extent);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetExtent(dymaptic.GeoBlazor.Core.Components.Geometries.Extent).extent'></a>

`extent` [Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetScale(double)'></a>

## SceneView.SetScale(double) Method

Sets the scale of the current view.

```csharp
public override System.Threading.Tasks.Task SetScale(double scale);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetScale(double).scale'></a>

`scale` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetZoom(double)'></a>

## SceneView.SetZoom(double) Method

Sets the zoom level of the current view.

```csharp
public override System.Threading.Tasks.Task SetZoom(double zoom);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.SetZoom(double).zoom'></a>

`zoom` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
