---
layout: default
title: ElementExpressionInfo
parent: Classes
---
---
layout: default
title: ElementExpressionInfo
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## ElementExpressionInfo Class

Defines an Arcade expression used to create an ExpressionContent element in a PopupTemplate. The expression must  
evaluate to a dictionary, representing a TextContent, FieldsContent, or MediaContent popup element as defined in  
the Popup Element web map specification.  
This expression may access data values from the feature, its layer, or other layers in the map or datastore with  
the $feature, $layer, $map, and $datastore profile variables. See the Popup Element Arcade Profile specification  
for more information and examples of valid return dictionaries.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class ElementExpressionInfo
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ElementExpressionInfo
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ElementExpressionInfo.Expression'></a>

## ElementExpressionInfo.Expression Property

The Arcade expression evaluating to a dictionary. The dictionary must represent either a TextContent,  
FieldsContent, or a MediaContent popup content element as defined in the Popup Element web map specification.  
This expression may access data values from the feature, its layer, or other layers in the map or datastore with  
the $feature, $layer, $map, and $datastore profile variables. See the Popup Element Arcade Profile specification  
for more information and examples of valid return dictionaries.

```csharp
public string? Expression { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ElementExpressionInfo.ReturnType'></a>

## ElementExpressionInfo.ReturnType Property

The return type of the expression. Content element expressions always return dictionaries.  
For ElementExpressionInfo the returnType is always "dictionary".

```csharp
public string? ReturnType { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ElementExpressionInfo.Title'></a>

## ElementExpressionInfo.Title Property

The title used to describe the popup element returned by the expression.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

