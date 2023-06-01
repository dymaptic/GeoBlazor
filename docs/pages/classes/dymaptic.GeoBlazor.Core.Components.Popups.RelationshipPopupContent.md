---
layout: default
title: RelationshipPopupContent
parent: Classes
---
---
layout: default
title: RelationshipPopupContent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## RelationshipPopupContent Class

A RelationshipContent popup element represents a relationship element associated with a feature. This can only be  
configured if the related layer or table is added to the map.  
RelationshipContent provides a way to browse related records of the current selected feature within its popup, as  
shown in the images below. The Origin Feature image shows a popup template configured with RelationshipContent.  
When selecting one of the related features in the list, the popup template for the chosen related destination  
feature displays. The Related Destination Feature image shows the destination popup template content with  
FieldsContent and RelationshipContent configured. When exploring a related feature's RelationshipContent, one could  
navigate into that feature's related records or exit the origin feature's related record exploration with the arrow  
button.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-RelationshipContent.html">ArcGIS JS API</a>

```csharp
public class RelationshipPopupContent : dymaptic.GeoBlazor.Core.Components.Popups.PopupContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent') &#129106; RelationshipPopupContent
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.Description'></a>

## RelationshipPopupContent.Description Property

Describes the relationship's content in detail.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.DisplayCount'></a>

## RelationshipPopupContent.DisplayCount Property

A numeric value indicating the maximum number of related features to display in the list of related records. The  
maximum number of related records to display in the list of related records is 10. If no value is specified, the  
Show all button will be available to display all related records.

```csharp
public System.Nullable<int> DisplayCount { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.DisplayType'></a>

## RelationshipPopupContent.DisplayType Property

A string value indicating how to display related records within the relationship content.

```csharp
public string? DisplayType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.OrderByFields'></a>

## RelationshipPopupContent.OrderByFields Property

An array of RelatedRecordsInfoFieldOrder indicating the display order for the related records, and whether they  
should be sorted in ascending asc or descending desc order.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Popups.RelatedRecordsInfoFieldOrder> OrderByFields { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[RelatedRecordsInfoFieldOrder](dymaptic.GeoBlazor.Core.Components.Popups.RelatedRecordsInfoFieldOrder.html 'dymaptic.GeoBlazor.Core.Components.Popups.RelatedRecordsInfoFieldOrder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.RelationshipId'></a>

## RelationshipPopupContent.RelationshipId Property

The numeric id value for the defined relationship. This value can be found on the service itself or on the  
service's relationships resource if supportsRelationshipResource is true.

```csharp
public System.Nullable<int> RelationshipId { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.Title'></a>

## RelationshipPopupContent.Title Property

A heading indicating what the relationship's content represents.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.Type'></a>

## RelationshipPopupContent.Type Property

The type of Popup Content

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

