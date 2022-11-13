---
layout: default
title: Field
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## Field Class

Information about each field in a layer. Field objects must be constructed when creating a FeatureLayer from client-side graphics. This class allows you to define the schema of each field in the FeatureLayer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Field.html">ArcGIS JS API</a>

```csharp
public class Field : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Field
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field()'></a>

## Field() Constructor

Parameterless constructor for use as a razor component

```csharp
public Field();
```

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_)'></a>

## Field(FieldType, string, string, string, Nullable<int>, Nullable<bool>, Nullable<bool>, object, Nullable<FieldValueType>) Constructor

Creates a new Field in code with parameters

```csharp
public Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType type, string? name=null, string? alias=null, string? description=null, System.Nullable<int> length=null, System.Nullable<bool> editable=null, System.Nullable<bool> nullable=null, object? defaultValue=null, System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType> valueType=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).type'></a>

`type` [FieldType](dymaptic.GeoBlazor.Core.Components.Layers.FieldType.html 'dymaptic.GeoBlazor.Core.Components.Layers.FieldType')

The data type of the field.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the field.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).alias'></a>

`alias` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The display name for the field.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Contains information describing the purpose of each field.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).length'></a>

`length` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The field length.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).editable'></a>

`editable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates whether the field is editable.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).nullable'></a>

`nullable` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the field can accept null values.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).defaultValue'></a>

`defaultValue` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The default value set for the field.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Field(dymaptic.GeoBlazor.Core.Components.Layers.FieldType,string,string,string,System.Nullable_int_,System.Nullable_bool_,System.Nullable_bool_,object,System.Nullable_dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType_).valueType'></a>

`valueType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[FieldValueType](dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType.html 'dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The types of values that can be assigned to a field.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Alias'></a>

## Field.Alias Property

The display name for the field.

```csharp
public string? Alias { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.DefaultValue'></a>

## Field.DefaultValue Property

The default value set for the field.

```csharp
public object? DefaultValue { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Description'></a>

## Field.Description Property

Contains information describing the purpose of each field.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Editable'></a>

## Field.Editable Property

Indicates whether the field is editable.

```csharp
public System.Nullable<bool> Editable { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Length'></a>

## Field.Length Property

The field length.

```csharp
public System.Nullable<int> Length { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Name'></a>

## Field.Name Property

The name of the field.

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Nullable'></a>

## Field.Nullable Property

Indicates if the field can accept null values.

```csharp
public System.Nullable<bool> Nullable { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.Type'></a>

## Field.Type Property

The data type of the field.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.FieldType Type { get; set; }
```

#### Property Value
[FieldType](dymaptic.GeoBlazor.Core.Components.Layers.FieldType.html 'dymaptic.GeoBlazor.Core.Components.Layers.FieldType')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Field.ValueType'></a>

## Field.ValueType Property

The types of values that can be assigned to a field.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType> ValueType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[FieldValueType](dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType.html 'dymaptic.GeoBlazor.Core.Components.Layers.FieldValueType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
