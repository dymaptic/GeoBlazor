---
layout: default
title: ExpressionInfo
parent: Classes
---
---
layout: default
title: ExpressionInfo
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## ExpressionInfo Class

The ExpressionInfo class references Arcade expressions following the specification defined by the Arcade Popup  
Profile. Expressions must return a string or a number and may access data values from the feature, its layer, or  
other layers in the map or datastore with the $feature, $layer, $map, and $datastore profile variables.  
Expression names are referenced in a layer's PopupTemplate and execute once a layer's popup is opened. The values  
display within the view's popup as if they are field values. They can be displayed in a table using the FieldInfo  
of the popupTemplate's content or referenced within a simple string.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ExpressionInfo.html">  
    ArcGIS  
    API for JS  
</a>

```csharp
public class ExpressionInfo : dymaptic.GeoBlazor.Core.Components.MapComponent,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; ExpressionInfo

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ExpressionInfo](dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Expression'></a>

## ExpressionInfo.Expression Property

An Arcade expression following the specification defined by the Arcade Popup Profile. Expressions must return a  
string or a number and may access data values from the feature, its layer, or other layers in the map or datastore  
with the $feature, $layer, $map, and $datastore profile variables.

```csharp
public string? Expression { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Name'></a>

## ExpressionInfo.Name Property

The name of the expression. This is used to reference the value of the given expression in the popupTemplate's  
content property by wrapping it in curly braces and prefacing it with expression/ (e.g.  
{expression/expressionName}).

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.ReturnType'></a>

## ExpressionInfo.ReturnType Property

Indicates the return type of the Arcade expression.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Popups.ReturnType> ReturnType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ReturnType](dymaptic.GeoBlazor.Core.Components.Popups.ReturnType.html 'dymaptic.GeoBlazor.Core.Components.Popups.ReturnType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Title'></a>

## ExpressionInfo.Title Property

The title used to describe the value returned by the expression in the popup. This will display if the value is  
referenced in a FieldInfo table.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Equals(object)'></a>

## ExpressionInfo.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.GetHashCode()'></a>

## ExpressionInfo.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.op_Equality(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo,dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo)'></a>

## ExpressionInfo.operator ==(ExpressionInfo, ExpressionInfo) Operator

Equality operator.

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo? left, dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.op_Equality(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo,dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo).left'></a>

`left` [ExpressionInfo](dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.op_Equality(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo,dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo).right'></a>

`right` [ExpressionInfo](dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.op_Inequality(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo,dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo)'></a>

## ExpressionInfo.operator !=(ExpressionInfo, ExpressionInfo) Operator

Inequality operator.

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo? left, dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.op_Inequality(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo,dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo).left'></a>

`left` [ExpressionInfo](dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.op_Inequality(dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo,dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo).right'></a>

`right` [ExpressionInfo](dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

