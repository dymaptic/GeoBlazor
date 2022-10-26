---
layout: default
title: MapFont
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## MapFont Class

The font used to display 2D text symbols and 3D text symbols. This class allows the developer to set the font's family, decoration, size, style, and weight properties. Take note of the "Known Limitations" for each property to understand how they differ depending on the layer type, and if you working with a MapView or SceneView.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html">ArcGIS JS API</a>

```csharp
public class MapFont : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; MapFont
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Family'></a>

## MapFont.Family Property

The font family of the text.

```csharp
public string? Family { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.FontStyle'></a>

## MapFont.FontStyle Property

The text style.

```csharp
public string? FontStyle { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Size'></a>

## MapFont.Size Property

The font size in points.

```csharp
public string? Size { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.Weight'></a>

## MapFont.Weight Property

The text weight.

```csharp
public string? Weight { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
