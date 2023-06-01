---
layout: default
title: LayerObject
parent: Classes
---
---
layout: default
title: LayerObject
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## LayerObject Class

Abstract base class for objects that are a child of a [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') and have a [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol')  
property.

```csharp
public abstract class LayerObject : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; LayerObject

Derived  
&#8627; [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')  
&#8627; [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')  
&#8627; [Renderer](dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.Renderer')  
&#8627; [UniqueValueInfo](dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueInfo.html 'dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueInfo')
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

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.GetSymbol()'></a>

## LayerObject.GetSymbol() Method

Gets the current [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') for the object.

```csharp
public virtual System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Symbols.Symbol?> GetSymbol();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## LayerObject.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

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

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.SetSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol)'></a>

## LayerObject.SetSymbol(Symbol) Method

Sets the [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') for the object.

```csharp
public virtual System.Threading.Tasks.Task SetSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol symbol);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.SetSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol).symbol'></a>

`symbol` [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

The [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') for the object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

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

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.

