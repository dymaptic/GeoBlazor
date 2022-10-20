---
layout: default
title: LabelExpressionInfo
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## LabelExpressionInfo Class

If working with a MapImageLayer that supports Arcade, you can also use labelExpressionInfo. To determine this, check the supportsArcadeExpressionForLabeling property. If true, then labelExpression or labelExpressionInfo can be used. If false, then only labelExpression can be used.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpressionInfo">ArcGIS JS API</a>

```csharp
public class LabelExpressionInfo : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; LabelExpressionInfo

### Remarks
MapImageLayer not yet implemented in GeoBlazor
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo.Expression'></a>

## LabelExpressionInfo.Expression Property

An Arcade expression following the specification defined by the Arcade Labeling Profile. Expressions in labels may reference field values using the $feature global variable and must return a string.

```csharp
public string Expression { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
