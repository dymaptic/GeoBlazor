---
layout: default
title: Relationship
parent: Classes
---
---
layout: default
title: Relationship
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## Relationship Class

Describes a layer's relationship with another layer or table. These relationships are listed in the ArcGIS Services  
directory as described in the REST API documentation.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Relationship.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class Relationship
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Relationship
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.Cardinality'></a>

## Relationship.Cardinality Property

The cardinality which specifies the number of objects in the origin FeatureLayer related to the number of objects  
in the destination FeatureLayer. Please see the Desktop help for additional information on cardinality.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.Cardinality> Cardinality { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[Cardinality](dymaptic.GeoBlazor.Core.Objects.Cardinality.html 'dymaptic.GeoBlazor.Core.Objects.Cardinality')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.Composite'></a>

## Relationship.Composite Property

Indicates whether the relationship is composite. In a composite relationship, a destination object cannot exist  
independently of its origin object.

```csharp
public System.Nullable<bool> Composite { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.Id'></a>

## Relationship.Id Property

The unique ID for the relationship. These ids for the relationships the FeatureLayer participates in are listed in  
the ArcGIS Services directory.

```csharp
public System.Nullable<int> Id { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.KeyField'></a>

## Relationship.KeyField Property

The field used to establish the relate within the FeatureLayer.

```csharp
public string? KeyField { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.KeyFieldInRelationshipTable'></a>

## Relationship.KeyFieldInRelationshipTable Property

The key field in an attributed relationship class table that matches the keyField. This is returned only for  
attributed relationships.

```csharp
public string? KeyFieldInRelationshipTable { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.Name'></a>

## Relationship.Name Property

The name of the relationship.

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.RelatedTableId'></a>

## Relationship.RelatedTableId Property

The unique ID of the related FeatureLayer.

```csharp
public System.Nullable<int> RelatedTableId { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.RelationshipTableId'></a>

## Relationship.RelationshipTableId Property

The relationship table id.

```csharp
public System.Nullable<int> RelationshipTableId { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Objects.Relationship.Role'></a>

## Relationship.Role Property

Indicates whether the table participating in the relationship is the origin or destination table.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Objects.Role> Role { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[Role](dymaptic.GeoBlazor.Core.Objects.Role.html 'dymaptic.GeoBlazor.Core.Objects.Role')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

