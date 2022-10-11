---
layout: default
title: TextSymbol
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## TextSymbol Class

Text symbols are used to define the graphic for displaying labels on a FeatureLayer, CSVLayer, Sublayer, and StreamLayer in a 2D MapView. Text symbols can also be used to define the symbol property of Graphic if the geometry type is Point or Multipoint. With this class, you may alter the color, font, halo, and other properties of the label graphic.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-TextSymbol.html">ArcGIS JS API</a>

```csharp
public class TextSymbol : dymaptic.GeoBlazor.Core.Components.Symbols.Symbol
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; TextSymbol
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.Font'></a>

## TextSymbol.Font Property

The [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont') used to style the text.

```csharp
public dymaptic.GeoBlazor.Core.Components.Symbols.MapFont? Font { get; set; }
```

#### Property Value
[MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.HaloColor'></a>

## TextSymbol.HaloColor Property

The color of the text symbol's halo.

```csharp
public dymaptic.GeoBlazor.Core.Objects.MapColor? HaloColor { get; set; }
```

#### Property Value
[MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.HaloSize'></a>

## TextSymbol.HaloSize Property

The size in points of the text symbol's halo.

```csharp
public string? HaloSize { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.Type'></a>

## TextSymbol.Type Property

The symbol type

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## TextSymbol.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## TextSymbol.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.ValidateRequiredChildren()'></a>

## TextSymbol.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
