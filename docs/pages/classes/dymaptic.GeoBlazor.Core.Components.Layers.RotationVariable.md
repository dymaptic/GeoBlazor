---
layout: default
title: RotationVariable
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## RotationVariable Class

The rotation visual variable defines how features rendered with marker symbols or text symbols in a MapView are  
rotated. The rotation value is determined by mapping the values to data in a field, or by other arithmetic means  
with an Arcade expression.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-RotationVariable.html">ArcGIS JS API</a>

```csharp
public class RotationVariable : dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [VisualVariable](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable') &#129106; RotationVariable
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.RotationVariable.Axis'></a>

## RotationVariable.Axis Property

Only applicable when working in a SceneView.

```csharp
public string? Axis { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.RotationVariable.RotationType'></a>

## RotationVariable.RotationType Property

Defines the origin and direction of rotation depending on how the angle of rotation was measured.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.RotationType> RotationType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[RotationType](dymaptic.GeoBlazor.Core.Components.Layers.RotationType.html 'dymaptic.GeoBlazor.Core.Components.Layers.RotationType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.RotationVariable.VariableType'></a>

## RotationVariable.VariableType Property

The visual variable type.

```csharp
public override dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType VariableType { get; }
```

#### Property Value
[VisualVariableType](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType')
