---
layout: default
title: SpatialReference
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Geometries](index.html#dymaptic.GeoBlazor.Core.Components.Geometries 'dymaptic.GeoBlazor.Core.Components.Geometries')

## SpatialReference Class

Defines the spatial reference of a view, layer, or method parameters. This indicates the projected or geographic  
coordinate system used to locate geographic features in the map. Each projected and geographic coordinate system is  
defined by either a well-known ID (WKID) or a definition string (WKT). Note that for versions prior to ArcGIS 10,  
only WKID was supported. For a full list of supported spatial reference IDs and their corresponding definition  
strings, see Using spatial references.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class SpatialReference : dymaptic.GeoBlazor.Core.Components.MapComponent,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; SpatialReference

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.SpatialReference()'></a>

## SpatialReference() Constructor

Parameterless constructor for use as a razor component

```csharp
public SpatialReference();
```

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.SpatialReference(int)'></a>

## SpatialReference(int) Constructor

Creates a new SpatialReference in code with a Wkid

```csharp
public SpatialReference(int wkid);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.SpatialReference(int).wkid'></a>

`wkid` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The well-known Id for the spatial reference
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.ImageCoordinateSystem'></a>

## SpatialReference.ImageCoordinateSystem Property

An image coordinate system defines the spatial reference used to display the image in its original coordinates  
without distortion, map transformations or ortho-rectification.

```csharp
public object? ImageCoordinateSystem { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsGeographic'></a>

## SpatialReference.IsGeographic Property

Indicates if the spatial reference refers to a geographic coordinate system.

```csharp
public System.Nullable<bool> IsGeographic { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsWebMercator'></a>

## SpatialReference.IsWebMercator Property

Indicates if the wkid of the spatial reference object is one of the following values: 102113, 102100, 3857.

```csharp
public System.Nullable<bool> IsWebMercator { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsWgs84'></a>

## SpatialReference.IsWgs84 Property

Indicates if the wkid of the spatial reference object is 4326.

```csharp
public System.Nullable<bool> IsWgs84 { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.IsWrappable'></a>

## SpatialReference.IsWrappable Property

Indicates if the spatial reference of the map supports wrapping around the International Date Line.

```csharp
public System.Nullable<bool> IsWrappable { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.WebMercator'></a>

## SpatialReference.WebMercator Property

A convenience static instance for WebMercator Spatial Reference.

```csharp
public static dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference WebMercator { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Wgs84'></a>

## SpatialReference.Wgs84 Property

A convenience static instance for WGS84 Spatial Reference.

```csharp
public static dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference Wgs84 { get; set; }
```

#### Property Value
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Wkid'></a>

## SpatialReference.Wkid Property

The well-known ID of a spatial reference.

```csharp
public System.Nullable<int> Wkid { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Wkt'></a>

## SpatialReference.Wkt Property

The well-known text that defines a spatial reference.

```csharp
public string? Wkt { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Clone()'></a>

## SpatialReference.Clone() Method

Returns a deep clone of the Spatial Reference.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference Clone();
```

#### Returns
[SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Equals(object)'></a>

## SpatialReference.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.GetHashCode()'></a>

## SpatialReference.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference)'></a>

## SpatialReference.operator ==(SpatialReference, SpatialReference) Operator

Compares two SpatialReference objects for equality

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? left, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).left'></a>

`left` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.op_Equality(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).right'></a>

`right` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference)'></a>

## SpatialReference.operator !=(SpatialReference, SpatialReference) Operator

Compares two SpatialReference objects for inequality

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? left, dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).left'></a>

`left` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

<a name='dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.op_Inequality(dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference,dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference).right'></a>

`right` [SpatialReference](dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference.html 'dymaptic.GeoBlazor.Core.Components.Geometries.SpatialReference')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
