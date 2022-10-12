---
layout: default
title: VisualVariable
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## VisualVariable Class

The visual variable base class. See each of the subclasses that extend this class to learn how to create continuous data-driven thematic visualizations.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html">ArcGIS JS API</a>

```csharp
public abstract class VisualVariable : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; VisualVariable

Derived  
&#8627; [SizeVariable](dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.Field'></a>

## VisualVariable.Field Property

The name of the numeric attribute field that contains the data values used to determine the color/opacity/size/rotation of each feature.

```csharp
public string Field { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.VariableType'></a>

## VisualVariable.VariableType Property

The visual variable type.

```csharp
public virtual dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType VariableType { get; }
```

#### Property Value
[VisualVariableType](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType')
