---
layout: default
title: LayerInfo
parent: Classes
---
---
layout: default
title: LayerInfo
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## LayerInfo Class

Specifies a layer to display in the legend.

```csharp
public class LayerInfo : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; LayerInfo
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerInfo.Layer'></a>

## LayerInfo.Layer Property

A layer to display in the legend.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerInfo.SublayerIds'></a>

## LayerInfo.SublayerIds Property

Only applicable if the layer is a MapImageLayer. The IDs of the MapImageLayer sublayers for which to display legend  
information.

```csharp
public int[]? SublayerIds { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.LayerInfo.Title'></a>

## LayerInfo.Title Property

Specifies a title for the layer to display above its symbols and descriptions. If no title is specified the service  
name is used.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

