---
layout: default
title: Symbol
parent: Classes
---
---
layout: default
title: Symbol
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## Symbol Class

Symbol is the abstract base class for all symbols. Symbols represent point, line, polygon, and mesh geometries as vector graphics within a View. Symbols can only be set directly on individual graphics in a GraphicsLayer or in View.graphics. Otherwise they are assigned to a Renderer that is applied to a Layer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html">ArcGIS JS API</a>

```csharp
public abstract class Symbol : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Symbol

Derived  
&#8627; [FillSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.FillSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.FillSymbol')  
&#8627; [LineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol')  
&#8627; [MarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol')  
&#8627; [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.Color'></a>

## Symbol.Color Property

The color of the symbol.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapColor? Color { get; set; }
```

#### Property Value
[MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.Type'></a>

## Symbol.Type Property

The symbol type

```csharp
public virtual string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

