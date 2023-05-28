---
layout: default
title: SimpleRenderer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Renderers](index.html#dymaptic.GeoBlazor.Core.Components.Renderers 'dymaptic.GeoBlazor.Core.Components.Renderers')

## SimpleRenderer Class

SimpleRenderer renders all features in a Layer with one Symbol. This renderer may be used to simply visualize the  
location of geographic features.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-SimpleRenderer.html">ArcGIS JS API</a>

```csharp
public class SimpleRenderer : dymaptic.GeoBlazor.Core.Components.Renderers.Renderer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [LayerObject](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject') &#129106; [Renderer](dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.Renderer') &#129106; SimpleRenderer
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.RendererType'></a>

## SimpleRenderer.RendererType Property

The subclass Renderer type

```csharp
public override dymaptic.GeoBlazor.Core.Components.Renderers.RendererType RendererType { get; }
```

#### Property Value
[RendererType](dymaptic.GeoBlazor.Core.Components.Renderers.RendererType.html 'dymaptic.GeoBlazor.Core.Components.Renderers.RendererType')

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.VisualVariables'></a>

## SimpleRenderer.VisualVariables Property

A collection of [VisualVariable](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable') objects.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable> VisualVariables { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[VisualVariable](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SimpleRenderer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SimpleRenderer.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.
