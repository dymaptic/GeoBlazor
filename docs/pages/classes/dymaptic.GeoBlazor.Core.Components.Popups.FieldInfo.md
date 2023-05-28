---
layout: default
title: FieldInfo
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## FieldInfo Class

The FieldInfo class defines how a Field participates, or in some cases, does not participate, in a PopupTemplate.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-FieldInfo.html">ArcGIS JS API</a>

```csharp
public class FieldInfo : dymaptic.GeoBlazor.Core.Components.MapComponent,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; FieldInfo

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo()'></a>

## FieldInfo() Constructor

Parameterless constructor for using as a razor component

```csharp
public FieldInfo();
```

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_)'></a>

## FieldInfo(string, string, string, string, FieldInfoFormat, Nullable<bool>, Nullable<bool>) Constructor

Constructor for creating a new FieldInfo in code with parameters

```csharp
public FieldInfo(string? fieldName=null, string? label=null, string? tooltip=null, string? stringFieldOption=null, dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat? format=null, System.Nullable<bool> isEditable=null, System.Nullable<bool> visible=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_).fieldName'></a>

`fieldName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The field name as defined by the service or the name of an Arcade expression.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_).label'></a>

`label` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The field name as defined by the service or the name of an Arcade expression.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_).tooltip'></a>

`tooltip` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string providing an editing hint for editors of the field.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_).stringFieldOption'></a>

`stringFieldOption` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string determining what type of input box editors see when editing the field.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_).format'></a>

`format` [FieldInfoFormat](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat')

Class which provides formatting options for numerical or date fields and how they should display within a popup.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_).isEditable'></a>

`isEditable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

A Boolean determining whether users can edit this field.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldInfo(string,string,string,string,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat,System.Nullable_bool_,System.Nullable_bool_).visible'></a>

`visible` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates whether the field is visible in the popup window.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.FieldName'></a>

## FieldInfo.FieldName Property

The field name as defined by the service or the name of an Arcade expression.

```csharp
public string? FieldName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.Format'></a>

## FieldInfo.Format Property

Class which provides formatting options for numerical or date fields and how they should display within a popup.

```csharp
public dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat? Format { get; set; }
```

#### Property Value
[FieldInfoFormat](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfoFormat')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.IsEditable'></a>

## FieldInfo.IsEditable Property

A Boolean determining whether users can edit this field.

```csharp
public System.Nullable<bool> IsEditable { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.Label'></a>

## FieldInfo.Label Property

The field name as defined by the service or the name of an Arcade expression.

```csharp
public string? Label { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.StringFieldOption'></a>

## FieldInfo.StringFieldOption Property

A string determining what type of input box editors see when editing the field.

```csharp
public string? StringFieldOption { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.Tooltip'></a>

## FieldInfo.Tooltip Property

A string providing an editing hint for editors of the field.

```csharp
public string? Tooltip { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.Visible'></a>

## FieldInfo.Visible Property

Indicates whether the field is visible in the popup window.

```csharp
public System.Nullable<bool> Visible { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.Equals(object)'></a>

## FieldInfo.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.GetHashCode()'></a>

## FieldInfo.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## FieldInfo.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## FieldInfo.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.op_Equality(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo)'></a>

## FieldInfo.operator ==(FieldInfo, FieldInfo) Operator

Equality operator

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo? left, dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.op_Equality(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo).left'></a>

`left` [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.op_Equality(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo).right'></a>

`right` [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.op_Inequality(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo)'></a>

## FieldInfo.operator !=(FieldInfo, FieldInfo) Operator

Inequality operator

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo? left, dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.op_Inequality(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo).left'></a>

`left` [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.op_Inequality(dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo,dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo).right'></a>

`right` [FieldInfo](dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldInfo')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
