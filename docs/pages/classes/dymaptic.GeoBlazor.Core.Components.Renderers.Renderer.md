---
layout: default
title: Renderer
parent: Classes
---
---
layout: default
title: Renderer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Renderers](index.html#dymaptic.GeoBlazor.Core.Components.Renderers 'dymaptic.GeoBlazor.Core.Components.Renderers')

## Renderer Class

Abstract base class, renderers define how to visually represent each feature in one of the following layer types:  
FeatureLayer, SceneLayer, MapImageLayer, CSVLayer, GeoJSONLayer, OGCFeatureLayer, StreamLayer, WFSLayer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-Renderer.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public abstract class Renderer : dymaptic.GeoBlazor.Core.Components.Layers.LayerObject
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [LayerObject](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject') &#129106; Renderer

Derived  
&#8627; [SimpleRenderer](dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.SimpleRenderer')  
&#8627; [UniqueValueRenderer](dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer.html 'dymaptic.GeoBlazor.Core.Components.Renderers.UniqueValueRenderer')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Renderers.Renderer.RendererType'></a>

## Renderer.RendererType Property

The subclass Renderer type

```csharp
public abstract dymaptic.GeoBlazor.Core.Components.Renderers.RendererType RendererType { get; }
```

#### Property Value
[RendererType](dymaptic.GeoBlazor.Core.Components.Renderers.RendererType.html 'dymaptic.GeoBlazor.Core.Components.Renderers.RendererType')

