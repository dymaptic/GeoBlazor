---
layout: default
title: ExpressionPopupContent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## ExpressionPopupContent Class

An ExpressionContent element allows you to define a popup content element with an Arcade expression. The expression  
must evaluate to a dictionary representing a TextContent, FieldsContent, or a MediaContent popup element as defined  
in the Popup Element web map specification.  
Expressions defining popup content typically use the attributes property of an element to reference values  
calculated within the expression in a table or a chart.  
This content element is designed for advanced scenarios where content in charts, tables, or rich text elements is  
based on logical conditions. For example, if data in one or more fields is empty, you can use this element to  
dynamically create a table consisting only of fields containing valid data values. You can also use this element to  
create charts or other content types consisting of aggregated data values. This can be especially useful in cluster  
popups.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ExpressionContent.html">ArcGIS JS API</a>

```csharp
public class ExpressionPopupContent : dymaptic.GeoBlazor.Core.Components.Popups.PopupContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [PopupContent](dymaptic.GeoBlazor.Core.Components.Popups.PopupContent.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupContent') &#129106; ExpressionPopupContent
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionPopupContent.ExpressionInfo'></a>

## ExpressionPopupContent.ExpressionInfo Property

Contains the Arcade expression used to create a popup content element. See the ElementExpressionInfo documentation  
for details and examples for how to create these expressions.

```csharp
public dymaptic.GeoBlazor.Core.Components.Popups.ElementExpressionInfo? ExpressionInfo { get; set; }
```

#### Property Value
[ElementExpressionInfo](dymaptic.GeoBlazor.Core.Components.Popups.ElementExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Popups.ElementExpressionInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionPopupContent.Type'></a>

## ExpressionPopupContent.Type Property

The type of Popup Content

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
