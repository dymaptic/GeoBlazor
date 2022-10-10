---
layout: default
title: Graphic
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## Graphic Class

A Graphic is a vector representation of real world geographic phenomena. It can contain geometry, a symbol, and attributes. A Graphic is displayed in the GraphicsLayer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">ArcGIS JS API</a>

```csharp
public class Graphic : dymaptic.GeoBlazor.Core.Components.Layers.LayerObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [dymaptic.GeoBlazor.Core.Components.Layers.LayerObject](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Layers.LayerObject 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject') &#129106; Graphic
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Attributes'></a>

## Graphic.Attributes Property

Name-value pairs of fields and field values associated with the graphic.

```csharp
public dymaptic.GeoBlazor.Core.Components.Attributes? Attributes { get; set; }
```

#### Property Value
[dymaptic.GeoBlazor.Core.Components.Attributes](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Attributes 'dymaptic.GeoBlazor.Core.Components.Attributes')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry'></a>

## Graphic.Geometry Property

The geometry that defines the graphic's location.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? Geometry { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GraphicIndex'></a>

## Graphic.GraphicIndex Property

The position of the graphic in its parent layer's collection.

```csharp
public System.Nullable<int> GraphicIndex { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate'></a>

## Graphic.PopupTemplate Property

The [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate') for displaying content in a Popup when the graphic is selected.

```csharp
public dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate? PopupTemplate { get; set; }
```

#### Property Value
[dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetGeometry()'></a>

## Graphic.GetGeometry() Method

Retrieves the [Geometry](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry') from the rendered graphic.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry> GetGeometry();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Graphic.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Graphic.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.UpdateComponent()'></a>

## Graphic.UpdateComponent() Method

Checks if the map is already rendered, and if so, performs forced updates as defined by the component type.

```csharp
public override System.Threading.Tasks.Task UpdateComponent();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.ValidateRequiredChildren()'></a>

## Graphic.ValidateRequiredChildren() Method

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
