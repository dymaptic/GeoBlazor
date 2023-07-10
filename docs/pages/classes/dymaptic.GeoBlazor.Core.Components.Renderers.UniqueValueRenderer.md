---
layout: default
title: UniqueValueRenderer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Renderers](index.html#dymaptic.GeoBlazor.Core.Components.Renderers 'dymaptic.GeoBlazor.Core.Components.Renderers')

## UniqueValueRenderer Class

UniqueValueRenderer allows you to symbolize features in a Layer based on one or more matching string attributes.  
This is typically done by using unique colors, fill styles, or images to represent features with equal values in a  
string field.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-UniqueValueRenderer.html">ArcGIS JS API</a>

```csharp
public class UniqueValueRenderer : dymaptic.GeoBlazor.Core.Components.Renderers.Renderer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [LayerObject](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject') &#129106; [Renderer](dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.Renderer') &#129106; UniqueValueRenderer
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.DefaultLabel'></a>

## UniqueValueRenderer.DefaultLabel Property

Label used in the Legend to describe features assigned the default symbol.

```csharp
public string? DefaultLabel { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.DefaultSymbol'></a>

## UniqueValueRenderer.DefaultSymbol Property

The default symbol used to draw a feature whose value is not matched or specified by the renderer.

```csharp
public dymaptic.GeoBlazor.Core.Components.Symbols.Symbol? DefaultSymbol { get; }
```

#### Property Value
[Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.Field'></a>

## UniqueValueRenderer.Field Property

The name of the attribute field the renderer uses to match unique values or types.

```csharp
public string? Field { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.LegendOptions'></a>

## UniqueValueRenderer.LegendOptions Property

An object providing options for displaying the renderer in the Legend.

```csharp
public dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRendererLegendOptions? LegendOptions { get; set; }
```

#### Property Value
[UniqueValueRendererLegendOptions](dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRendererLegendOptions.html 'dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRendererLegendOptions')

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.RendererType'></a>

## UniqueValueRenderer.RendererType Property

The subclass Renderer type

```csharp
public override dymaptic.GeoBlazor.Core.Components.Renderers.RendererType RendererType { get; }
```

#### Property Value
[RendererType](dymaptic.GeoBlazor.Core.Components.Renderers.RendererType.html 'dymaptic.GeoBlazor.Core.Components.Renderers.RendererType')

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.UniqueValueInfos'></a>

## UniqueValueRenderer.UniqueValueInfos Property

Each element in the array is an object that provides information about a unique value associated with the renderer.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueInfo> UniqueValueInfos { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[UniqueValueInfo](dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueInfo.html 'dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## UniqueValueRenderer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## UniqueValueRenderer.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.
