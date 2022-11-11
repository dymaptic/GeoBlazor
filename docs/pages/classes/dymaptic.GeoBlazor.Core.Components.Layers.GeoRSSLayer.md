---
layout: default
title: GeoRSSLayer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## GeoRSSLayer Class

The GeoRSSLayer class is used to create a layer based on GeoRSS. GeoRSS is a way to add geographic information to an RSS feed. The GeoRSSLayer supports both GeoRSS-Simple and GeoRSS GML encodings, and multiple geometry types.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoRSSLayer.html">ArcGIS JS API</a>

```csharp
public class GeoRSSLayer : dymaptic.GeoBlazor.Core.Components.Layers.Layer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer') &#129106; GeoRSSLayer
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.LayerType'></a>

## GeoRSSLayer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public override string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.Url'></a>

## GeoRSSLayer.Url Property

The url for the GeoRSS source data.

```csharp
public string? Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
