---
layout: default
title: SimpleLineSymbol
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## SimpleLineSymbol Class

SimpleLineSymbol is used for rendering 2D polyline geometries in a 2D MapView. SimpleLineSymbol is also used for rendering outlines for marker symbols and fill symbols.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html">ArcGIS JS API</a>

```csharp
public class SimpleLineSymbol : dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; [LineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineSymbol') &#129106; SimpleLineSymbol

Derived  
&#8627; [Outline](dymaptic.GeoBlazor.Core.Components.Symbols.Outline.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Outline')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.SimpleLineSymbol()'></a>

## SimpleLineSymbol() Constructor

Parameterless constructor for using as a razor component

```csharp
public SimpleLineSymbol();
```

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.SimpleLineSymbol(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_)'></a>

## SimpleLineSymbol(MapColor, Nullable<double>, Nullable<LineStyle>) Constructor

Constructs a new SimpleLineSymbol in code with parameters

```csharp
public SimpleLineSymbol(dymaptic.GeoBlazor.Core.Objects.MapColor? color=null, System.Nullable<double> width=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle> lineStyle=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.SimpleLineSymbol(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_).color'></a>

`color` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

The color of the line symbol.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.SimpleLineSymbol(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_).width'></a>

`width` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The width of the line symbol in points.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.SimpleLineSymbol(dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle_).lineStyle'></a>

`lineStyle` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LineStyle](dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The line style.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.LineStyle'></a>

## SimpleLineSymbol.LineStyle Property

Specifies the line style.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle> LineStyle { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[LineStyle](dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle.html 'dymaptic.GeoBlazor.Core.Components.Symbols.LineStyle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.Type'></a>

## SimpleLineSymbol.Type Property

The symbol type

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.Equals(object)'></a>

## SimpleLineSymbol.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.GetHashCode()'></a>

## SimpleLineSymbol.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol)'></a>

## SimpleLineSymbol.operator ==(SimpleLineSymbol, SimpleLineSymbol) Operator

Compares two [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol')s for equality

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol).left'></a>

`left` [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol).right'></a>

`right` [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol)'></a>

## SimpleLineSymbol.operator !=(SimpleLineSymbol, SimpleLineSymbol) Operator

Compares two [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol')s for inequality

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol).left'></a>

`left` [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol).right'></a>

`right` [SimpleLineSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
