---
layout: default
title: ExpressionInfo
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Popups](index.html#dymaptic.GeoBlazor.Core.Components.Popups 'dymaptic.GeoBlazor.Core.Components.Popups')

## ExpressionInfo Class

The ExpressionInfo class references Arcade expressions following the specification defined by the Arcade Popup  
Profile. Expressions must return a string or a number and may access data values from the feature, its layer, or  
other layers in the map or datastore with the $feature, $layer, $map, and $datastore profile variables.  
Expression names are referenced in a layer's PopupTemplate and execute once a layer's popup is opened. The values  
display within the view's popup as if they are field values. They can be displayed in a table using the FieldInfo  
of the popupTemplate's content or referenced within a simple string.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ExpressionInfo.html">  
    ArcGIS  
    API for JS  
</a>

```csharp
public class ExpressionInfo : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; ExpressionInfo
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Expression'></a>

## ExpressionInfo.Expression Property

An Arcade expression following the specification defined by the Arcade Popup Profile. Expressions must return a  
string or a number and may access data values from the feature, its layer, or other layers in the map or datastore  
with the $feature, $layer, $map, and $datastore profile variables.

```csharp
public string? Expression { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Name'></a>

## ExpressionInfo.Name Property

The name of the expression. This is used to reference the value of the given expression in the popupTemplate's  
content property by wrapping it in curly braces and prefacing it with expression/ (e.g.  
{expression/expressionName}).

```csharp
public string? Name { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.ReturnType'></a>

## ExpressionInfo.ReturnType Property

Indicates the return type of the Arcade expression.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Popups.ReturnType> ReturnType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ReturnType](dymaptic.GeoBlazor.Core.Components.Popups.ReturnType.html 'dymaptic.GeoBlazor.Core.Components.Popups.ReturnType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Popups.ExpressionInfo.Title'></a>

## ExpressionInfo.Title Property

The title used to describe the value returned by the expression in the popup. This will display if the value is  
referenced in a FieldInfo table.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
