---
layout: default
title: VisualVariable
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## VisualVariable Class

The visual variable base class. See each of the subclasses that extend this class to learn how to create continuous  
data-driven thematic visualizations.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public abstract class VisualVariable : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; VisualVariable

Derived  
&#8627; [RotationVariable](dymaptic.GeoBlazor.Core.Components.Layers.RotationVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.RotationVariable')  
&#8627; [SizeVariable](dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable.html 'dymaptic.GeoBlazor.Core.Components.Layers.SizeVariable')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.Field'></a>

## VisualVariable.Field Property

The name of the numeric attribute field that contains the data values used to determine the  
color/opacity/size/rotation of each feature.

```csharp
public string Field { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.LegendOptions'></a>

## VisualVariable.LegendOptions Property

An object providing options for displaying the visual variable in the Legend.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LegendOptions? LegendOptions { get; set; }
```

#### Property Value
[LegendOptions](dymaptic.GeoBlazor.Core.Components.Layers.LegendOptions.html 'dymaptic.GeoBlazor.Core.Components.Layers.LegendOptions')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.VariableType'></a>

## VisualVariable.VariableType Property

The visual variable type.

```csharp
public virtual dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType VariableType { get; }
```

#### Property Value
[VisualVariableType](dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType.html 'dymaptic.GeoBlazor.Core.Components.Layers.VisualVariableType')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## VisualVariable.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## VisualVariable.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.VisualVariable.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
