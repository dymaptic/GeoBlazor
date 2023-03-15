---
layout: default
title: AddressCandidate
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## AddressCandidate Class

Represents the result of a geocode service operation as a list of address candidates. This resource provides  
information about candidates, including the address, location, and match score.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AddressCandidate.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class AddressCandidate
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AddressCandidate
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.AddressCandidate.Address'></a>

## AddressCandidate.Address Property

Address of the candidate.

```csharp
public string? Address { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressCandidate.Attributes'></a>

## AddressCandidate.Attributes Property

Name value pairs of field name and field value as defined in outFields in locator.addressToLocations().

```csharp
public System.Collections.Generic.Dictionary<string,object> Attributes { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressCandidate.Extent'></a>

## AddressCandidate.Extent Property

The minimum and maximum X and Y coordinates of a bounding box of the address candidate.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent? Extent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressCandidate.Location'></a>

## AddressCandidate.Location Property

The Point object representing the location of the address.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Point? Location { get; set; }
```

#### Property Value
[Point](dymaptic.GeoBlazor.Core.Components.Geometries.Point.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Point')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressCandidate.Score'></a>

## AddressCandidate.Score Property

Numeric score between 0 and 100 for geocode candidates.

```csharp
public System.Nullable<double> Score { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
