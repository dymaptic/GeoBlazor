---
layout: default
title: SimpleMarkerSymbol
parent: Classes
---
---
layout: default
title: SimpleMarkerSymbol
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## SimpleMarkerSymbol Class

SimpleMarkerSymbol is used for rendering 2D Point geometries with a simple shape and color in either a MapView or a  
SceneView. It may be filled with a solid color and have an optional outline, which is defined with a  
SimpleLineSymbol.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class SimpleMarkerSymbol : dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; [MarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.MarkerSymbol') &#129106; SimpleMarkerSymbol

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[SimpleMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol()'></a>

## SimpleMarkerSymbol() Constructor

Parameterless constructor for using as a razor component

```csharp
public SimpleMarkerSymbol();
```

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_)'></a>

## SimpleMarkerSymbol(Outline, MapColor, Nullable<double>, string, Nullable<double>, Nullable<double>, Nullable<double>) Constructor

Constructs a new SimpleMarkerSymbol in code with parameters

```csharp
public SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline? outline=null, dymaptic.GeoBlazor.Core.Objects.MapColor? color=null, System.Nullable<double> size=null, string? style=null, System.Nullable<double> angle=null, System.Nullable<double> xOffset=null, System.Nullable<double> yOffset=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).outline'></a>

`outline` [Outline](dymaptic.GeoBlazor.Core.Components.Symbols.Outline.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Outline')

The outline of the marker symbol.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).color'></a>

`color` [MapColor](dymaptic.GeoBlazor.Core.Objects.MapColor.html 'dymaptic.GeoBlazor.Core.Objects.MapColor')

The color of the marker symbol.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).size'></a>

`size` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The size of the marker in points.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).style'></a>

`style` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The marker style.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).angle'></a>

`angle` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The angle of the marker relative to the screen in degrees.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).xOffset'></a>

`xOffset` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The offset on the x-axis in points.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.SimpleMarkerSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Outline,dymaptic.GeoBlazor.Core.Objects.MapColor,System.Nullable_double_,string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).yOffset'></a>

`yOffset` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The offset on the y-axis in points.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.Outline'></a>

## SimpleMarkerSymbol.Outline Property

The outline of the marker symbol.

```csharp
public dymaptic.GeoBlazor.Core.Components.Symbols.Outline? Outline { get; set; }
```

#### Property Value
[Outline](dymaptic.GeoBlazor.Core.Components.Symbols.Outline.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Outline')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.Size'></a>

## SimpleMarkerSymbol.Size Property

The size of the marker in points.

```csharp
public System.Nullable<double> Size { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.Style'></a>

## SimpleMarkerSymbol.Style Property

The marker style.

```csharp
public string? Style { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.Type'></a>

## SimpleMarkerSymbol.Type Property

The symbol type

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.Equals(object)'></a>

## SimpleMarkerSymbol.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.GetHashCode()'></a>

## SimpleMarkerSymbol.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SimpleMarkerSymbol.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SimpleMarkerSymbol.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.ValidateRequiredChildren()'></a>

## SimpleMarkerSymbol.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the  
[RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol)'></a>

## SimpleMarkerSymbol.operator ==(SimpleMarkerSymbol, SimpleMarkerSymbol) Operator

Compares two SimpleMarkerSymbol objects for equality

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol).left'></a>

`left` [SimpleMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.op_Equality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol).right'></a>

`right` [SimpleMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol)'></a>

## SimpleMarkerSymbol.operator !=(SimpleMarkerSymbol, SimpleMarkerSymbol) Operator

Compares two SimpleMarkerSymbol objects for inequality

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol? left, dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol).left'></a>

`left` [SimpleMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.op_Inequality(dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol,dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol).right'></a>

`right` [SimpleMarkerSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

