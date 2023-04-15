---
layout: default
title: PopupContent
parent: Classes
---
---
layout: default
title: PopupContent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## PopupContent Class

Abstract base class, PopupContent elements define what should display within the PopupTemplate content.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-Content.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public abstract class PopupContent : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; PopupContent

Derived  
&#8627; [AttachmentsPopupContent](dymaptic.GeoBlazor.Core.Components.Popups.AttachmentsPopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.AttachmentsPopupContent')  
&#8627; [ExpressionPopupContent](dymaptic.GeoBlazor.Core.Components.Popups.ExpressionPopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.ExpressionPopupContent')  
&#8627; [FieldsPopupContent](dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.FieldsPopupContent')  
&#8627; [MediaPopupContent](dymaptic.GeoBlazor.Core.Components.Popups.MediaPopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.MediaPopupContent')  
&#8627; [RelationshipPopupContent](dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.RelationshipPopupContent')  
&#8627; [TextPopupContent](dymaptic.GeoBlazor.Core.Components.Popups.TextPopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.TextPopupContent')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.Type'></a>

## PopupContent.Type Property

The type of Popup Content

```csharp
public abstract string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

