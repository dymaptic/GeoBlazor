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
public class TextSymbol : dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; TextSymbol

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.TextSymbol()'></a>

## TextSymbol() Constructor

Parameterless constructor for use as a razor component

```csharp
public TextSymbol();
```

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.TextSymbol(string,dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,string,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont)'></a>

## TextSymbol(string, MapColor, MapColor, string, MapFont) Constructor

Constructor for use in code

```csharp
public TextSymbol(string text, dymaptic.GeoBlazor.Core.Objects.MapColor? color=null, dymaptic.GeoBlazor.Core.Objects.MapColor? haloColor=null, string? haloSize=null, dymaptic.GeoBlazor.Core.Components.Symbols.MapFont? font=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.TextSymbol(string,dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,string,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text string to display in the view.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.TextSymbol(string,dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,string,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).color'></a>

`color` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

The color of the symbol.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.TextSymbol(string,dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,string,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).haloColor'></a>

`haloColor` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

The color of the text symbol's halo.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.TextSymbol(string,dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,string,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).haloSize'></a>

`haloSize` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The size in points of the text symbol's halo.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.TextSymbol(string,dymaptic.GeoBlazor.Core.Objects.MapColor,dymaptic.GeoBlazor.Core.Objects.MapColor,string,dymaptic.GeoBlazor.Core.Components.Symbols.MapFont).font'></a>

`font` [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont')

The [MapFont](dymaptic.GeoBlazor.Core.Components.Symbols.MapFont.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MapFont') used to style the text.
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

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.Text'></a>

## TextSymbol.Text Property

The text string to display in the view.

```csharp
public string? Text { get; set; }
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

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.Equals(object)'></a>

## TextSymbol.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.GetHashCode()'></a>

## TextSymbol.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.

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
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol)'></a>

## TextSymbol.operator ==(TextSymbol, TextSymbol) Operator

Compares two [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol') objects for equality.

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol).left'></a>

`left` [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol).right'></a>

`right` [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol)'></a>

## TextSymbol.operator !=(TextSymbol, TextSymbol) Operator

Compares two [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol') objects for inequality.

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol).left'></a>

`left` [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol).right'></a>

`right` [TextSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.TextSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
