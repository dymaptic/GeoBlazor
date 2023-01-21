---
layout: default
title: AddressQuery
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## AddressQuery Class

A collection of parameters to pass to locator.addressToLocations

```csharp
public class AddressQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AddressQuery
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.AddressQuery.Address'></a>

## AddressQuery.Address Property

The address argument is data object that contains properties representing the various address fields accepted by the corresponding geocode service. These fields are listed in the addressFields property of the associated geocode service resource.

```csharp
public dymaptic.GeoBlazor.Core.Objects.Address? Address { get; set; }
```

#### Property Value
[Address](dymaptic.GeoBlazor.Core.Objects.Address.html 'dymaptic.GeoBlazor.Core.Objects.Address')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressQuery.Categories'></a>

## AddressQuery.Categories Property

Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food". Only applies to the World Geocode Service. See Category filtering (World Geocoding Service) for more information.

```csharp
public System.Collections.Generic.HashSet<string>? Categories { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressQuery.LocatorUrl'></a>

## AddressQuery.LocatorUrl Property

URL to the ArcGIS Server REST resource that represents a locator service.

```csharp
public string? LocatorUrl { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressQuery.MaxLocations'></a>

## AddressQuery.MaxLocations Property

Maximum results to return from the query.

```csharp
public System.Nullable<int> MaxLocations { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.AddressQuery.OutFields'></a>

## AddressQuery.OutFields Property

The list of fields included in the returned result set. This list is a comma delimited list of field names. If you specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection candidate fields.

```csharp
public System.Collections.Generic.HashSet<string>? OutFields { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')
