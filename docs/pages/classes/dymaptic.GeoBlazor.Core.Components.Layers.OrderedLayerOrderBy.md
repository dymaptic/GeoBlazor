---
layout: default
title: OrderedLayerOrderBy
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## OrderedLayerOrderBy Class

Determines the order in which features are drawn in the view.

```csharp
public class OrderedLayerOrderBy : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; OrderedLayerOrderBy
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy.Field'></a>

## OrderedLayerOrderBy.Field Property

The number or date field whose values will be used to sort features.

```csharp
public string? Field { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy.Order'></a>

## OrderedLayerOrderBy.Order Property

The sort order

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.SortOrder> Order { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[SortOrder](dymaptic.GeoBlazor.Core.Components.Layers.SortOrder.html 'dymaptic.GeoBlazor.Core.Components.Layers.SortOrder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.OrderedLayerOrderBy.ValueExpression'></a>

## OrderedLayerOrderBy.ValueExpression Property

An [Arcade](https://developers.arcgis.com/javascript/latest/arcade/) expression following the specification defined  
by the [Arcade Feature Z Profile](https://developers.arcgis.com/javascript/latest/arcade/#feature-sorting).

```csharp
public string? ValueExpression { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
