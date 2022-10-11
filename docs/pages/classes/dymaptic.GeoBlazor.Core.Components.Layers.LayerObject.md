---
layout: default
title: LayerObject
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## LayerObject Class

Abstract base class for objects that are a child of a [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') and have a [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') property.

```csharp
public abstract class LayerObject : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; LayerObject

Derived  
&#8627; [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')  
&#8627; [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')  
&#8627; [Renderer](dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.Renderer')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol'></a>

## LayerObject.Symbol Property

The [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') for the object.

```csharp
public dymaptic.GeoBlazor.Core.Components.Symbols.Symbol? Symbol { get; set; }
```

#### Property Value
[Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## LayerObject.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## LayerObject.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.ValidateRequiredChildren()'></a>

## LayerObject.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
