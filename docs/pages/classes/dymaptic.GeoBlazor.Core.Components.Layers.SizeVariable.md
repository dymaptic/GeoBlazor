---
layout: default
title: SizeVariable
parent: Classes
---
---
layout: default
title: SizeVariable
parent: Classes
---
---
layout: default
title: SizeVariable
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## SizeVariable Class

The size visual variable defines the size of individual features in a layer based on a numeric (often thematic) value.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html">ArcGIS JS API</a>

```csharp
public class SizeVariable : dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [VisualVariable](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable') &#129106; SizeVariable
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.MaxDataValue'></a>

## SizeVariable.MaxDataValue Property

The maximum data value used in the size ramp.

```csharp
public System.Nullable<double> MaxDataValue { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.MaxSize'></a>

## SizeVariable.MaxSize Property

The size used to render a feature containing the maximum data value

```csharp
public System.Nullable<double> MaxSize { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.MinDataValue'></a>

## SizeVariable.MinDataValue Property

The minimum data value used in the size ramp.

```csharp
public System.Nullable<double> MinDataValue { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.MinSize'></a>

## SizeVariable.MinSize Property

The size used to render a feature containing the minimum data value

```csharp
public System.Nullable<double> MinSize { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.VariableType'></a>

## SizeVariable.VariableType Property

The visual variable type.

```csharp
public override dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType VariableType { get; }
```

#### Property Value
[VisualVariableType](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType')


