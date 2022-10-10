---
layout: default
title: SceneView
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Views](index.html#dymaptic.GeoBlazor.Core.Components.Views 'dymaptic.GeoBlazor.Core.Components.Views')

## SceneView Class

A SceneView displays a 3D view of a Map or WebScene instance using WebGL. To render a map and its layers in 2D, see the documentation for MapView. For a general overview of views, see View.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">ArcGIS JS API</a>

```csharp
public class SceneView : dymaptic.GeoBlazor.Core.Components.Views.MapView
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') &#129106; SceneView

### Example
<a target="_blank" href="https://blazor.dymaptic.com/web-scene">Sample - Web Scene</a>
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.Tilt'></a>

## SceneView.Tilt Property

The tilt of the camera in degrees with respect to the surface as projected down from the camera position.

```csharp
public System.Nullable<double> Tilt { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.WebScene'></a>

## SceneView.WebScene Property

An instance of a [WebScene](dymaptic.GeoBlazor.Core.Components.Views.SceneView.html#dymaptic.GeoBlazor.Core.Components.Views.SceneView.WebScene 'dymaptic.GeoBlazor.Core.Components.Views.SceneView.WebScene') object to display in the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.WebScene? WebScene { get; set; }
```

#### Property Value
[dymaptic.GeoBlazor.Core.Components.WebScene](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.WebScene 'dymaptic.GeoBlazor.Core.Components.WebScene')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.ZIndex'></a>

## SceneView.ZIndex Property

The Z-Index (elevation) of the camera position over the view.

```csharp
public System.Nullable<double> ZIndex { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SceneView.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SceneView.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Views.SceneView.ValidateRequiredChildren()'></a>

## SceneView.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that  
all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
