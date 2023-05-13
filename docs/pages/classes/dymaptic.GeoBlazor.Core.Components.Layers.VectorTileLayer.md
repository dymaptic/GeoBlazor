---
layout: default
title: VectorTileLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## VectorTileLayer Class

VectorTileLayer accesses cached tiles of data and renders it in vector format. It is similar to a WebTileLayer in  
the context of caching; however, a WebTileLayer renders as a series of images, not vector data. Unlike raster  
tiles, vector tiles can adapt to the resolution of their display device and can be restyled for multiple uses.  
VectorTileLayer delivers styled maps while taking advantage of cached raster map tiles with vector map data.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class VectorTileLayer : dymaptic.GeoBlazor.Core.Components.Layers.TileLayer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; [TileLayer](dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.TileLayer') &#129106; VectorTileLayer
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.LayerType'></a>

## VectorTileLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
