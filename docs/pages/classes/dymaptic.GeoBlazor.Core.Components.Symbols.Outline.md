---
layout: default
title: Outline
parent: Classes
---
---
layout: default
title: Outline
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## Outline Class

A convenience sub-class of [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol') for defining outlines of other symbols.

```csharp
public class Outline : dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; [LineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol') &#129106; [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol') &#129106; Outline
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.Outline.Outline()'></a>

## Outline() Constructor

Parameterless constructor for using as a razor component

```csharp
public Outline();
```

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.Outline.Outline(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_)'></a>

## Outline(MapColor, Nullable<double>, Nullable<LineStyle>) Constructor

Constructs a new Outline in code with parameters

```csharp
public Outline(dymaptic.GeoBlazor.Core.Objects.MapColor? color=null, System.Nullable<double> width=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle> lineStyle=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.Outline.Outline(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_).color'></a>

`color` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

The color of the outline.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.Outline.Outline(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_).width'></a>

`width` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The width of the outline in points.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.Outline.Outline(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_).lineStyle'></a>

`lineStyle` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LineStyle](dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The style of the outline.

