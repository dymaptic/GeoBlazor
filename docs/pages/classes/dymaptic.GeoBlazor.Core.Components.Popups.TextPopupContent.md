---
layout: default
title: TextPopupContent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## TextPopupContent Class

A TextContent popup element is used to define descriptive text as an element within a PopupTemplate's content. The  
text may reference values returned from a field attribute or an Arcade expression defined in a PopupTemplate's  
expressionInfos property.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-TextContent.html">ArcGIS JS API</a>

```csharp
public class TextPopupContent : dymaptic.GeoBlazor.Core.Components.Popups.PopupContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent') &#129106; TextPopupContent
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.TextPopupContent.Text'></a>

## TextPopupContent.Text Property

The formatted string content to display. This may contain a field name enclosed in {} (e.g. {FIELDNAME}), or an  
Arcade expression name (e.g. {expression/EXPRESSIONNAME}). Text content may also leverage HTML tags such as <b></b>  
, <p></p>, and <table></table> for formatting the look and feel of the content.

```csharp
public string? Text { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
Set the popupTemplate.fieldInfos property for any fields that need to have number formatting within the text.

<a name='dymaptic.GeoBlazor.Core.Components.Popups.TextPopupContent.Type'></a>

## TextPopupContent.Type Property

The type of Popup Content

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
