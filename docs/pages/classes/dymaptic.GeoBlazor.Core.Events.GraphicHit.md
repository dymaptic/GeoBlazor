---
layout: default
title: GraphicHit
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## GraphicHit Class

Object specification for the [Results](dymaptic.GeoBlazor.Core.Events.HitTestResult.html#dymaptic.GeoBlazor.Core.Events.HitTestResult.Results 'dymaptic.GeoBlazor.Core.Events.HitTestResult.Results').  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#ViewHit">ArcGIS JS API</a>

```csharp
public class GraphicHit : dymaptic.GeoBlazor.Core.Events.ViewHit,
System.IEquatable<dymaptic.GeoBlazor.Core.Events.GraphicHit>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ViewHit](dymaptic.GeoBlazor.Core.Events.ViewHit.html 'dymaptic.GeoBlazor.Core.Events.ViewHit') &#129106; GraphicHit

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[GraphicHit](dymaptic.GeoBlazor.Core.Events.GraphicHit.html 'dymaptic.GeoBlazor.Core.Events.GraphicHit')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.GraphicHit.Graphic'></a>

## GraphicHit.Graphic Property

A graphic representing a feature in the view that intersects the input screen coordinates. If the graphic comes from a layer with an applied Renderer, then the symbol property will be empty. Other properties may be empty based on the context in which the graphic is fetched. If the result comes from a VectorTileLayer then a static graphic is returned with two attributes: layerId and layerName. These correspond to the name and id of the style-layer in the vector tile style.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Graphic Graphic { get; set; }
```

#### Property Value
[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

<a name='dymaptic.GeoBlazor.Core.Events.GraphicHit.Layer'></a>

## GraphicHit.Layer Property

The layer that contains the feature/graphic.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')
