---
layout: default
title: MediaPopupContent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## MediaPopupContent Class

A MediaContent popup element contains an individual or array of chart and/or image media elements to display within a popup's content.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-MediaContent.html">ArcGIS JS API</a>

```csharp
public class MediaPopupContent : dymaptic.GeoBlazor.Core.Components.Popups.PopupContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent') &#129106; MediaPopupContent
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.MediaPopupContent.ActiveMediaInfoIndex'></a>

## MediaPopupContent.ActiveMediaInfoIndex Property

Index of the current active media within the popup's media content. This will be the media that is currently viewed when displayed.

```csharp
public string? ActiveMediaInfoIndex { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.MediaPopupContent.Description'></a>

## MediaPopupContent.Description Property

Describes the media's content in detail.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.MediaPopupContent.MediaInfos'></a>

## MediaPopupContent.MediaInfos Property

Contains the media elements representing images or charts to display within the PopupTemplate. This can be an individual chart or image element, or an array containing a combination of any of these types.

```csharp
public System.Collections.Generic.HashSet<dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo> MediaInfos { get; set; }
```

#### Property Value
[System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[MediaInfo](dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.MediaInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.MediaPopupContent.Title'></a>

## MediaPopupContent.Title Property

Heading indicating what the media's content represents.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.MediaPopupContent.Type'></a>

## MediaPopupContent.Type Property

The type of Popup Content

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
