---
layout: default
title: AttachmentsPopupContent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## AttachmentsPopupContent Class

An AttachmentsContent popup element represents an attachment element associated with a feature. This resource is  
available only if the FeatureLayer.capabilities.data.supportsAttachment is true.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html">ArcGIS JS API</a>

```csharp
public class AttachmentsPopupContent : dymaptic.GeoBlazor.Core.Components.Popups.PopupContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent') &#129106; AttachmentsPopupContent
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.AttachmentsPopupContent.Description'></a>

## AttachmentsPopupContent.Description Property

Describes the attachment's content in detail.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.AttachmentsPopupContent.DisplayType'></a>

## AttachmentsPopupContent.DisplayType Property

A string value indicating how to display an attachment.

```csharp
public string? DisplayType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.AttachmentsPopupContent.Title'></a>

## AttachmentsPopupContent.Title Property

A heading indicating what the attachment's content represents.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.AttachmentsPopupContent.Type'></a>

## AttachmentsPopupContent.Type Property

The type of Popup Content

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
