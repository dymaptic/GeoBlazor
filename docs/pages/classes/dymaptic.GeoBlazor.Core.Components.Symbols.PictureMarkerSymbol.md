---
layout: default
title: PictureMarkerSymbol
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## PictureMarkerSymbol Class

PictureMarkerSymbol renders Point graphics in either a 2D MapView or 3D SceneView using an image. A url must point to a valid image. PictureMarkerSymbols may be applied to point features in a FeatureLayer or individual graphics.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-PictureMarkerSymbol.html">ArcGIS JS API</a>

```csharp
public class PictureMarkerSymbol : dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; [MarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol') &#129106; PictureMarkerSymbol

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[PictureMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.Height'></a>

## PictureMarkerSymbol.Height Property

The height of the image in points.

```csharp
public System.Nullable<double> Height { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.Type'></a>

## PictureMarkerSymbol.Type Property

The symbol type

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.Url'></a>

## PictureMarkerSymbol.Url Property

The URL to an image or SVG document.

```csharp
public string Url { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.Width'></a>

## PictureMarkerSymbol.Width Property

The width of the image in points.

```csharp
public System.Nullable<double> Width { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.Equals(object)'></a>

## PictureMarkerSymbol.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.GetHashCode()'></a>

## PictureMarkerSymbol.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol)'></a>

## PictureMarkerSymbol.operator ==(PictureMarkerSymbol, PictureMarkerSymbol) Operator

Compares two PictureMarkerSymbols for equality

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol).left'></a>

`left` [PictureMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol).right'></a>

`right` [PictureMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol)'></a>

## PictureMarkerSymbol.operator !=(PictureMarkerSymbol, PictureMarkerSymbol) Operator

Compares two PictureMarkerSymbols for inequality

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol).left'></a>

`left` [PictureMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol).right'></a>

`right` [PictureMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.PictureMarkerSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
