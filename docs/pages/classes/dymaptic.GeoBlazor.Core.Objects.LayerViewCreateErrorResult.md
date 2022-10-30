---
layout: default
title: LayerViewCreateErrorResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## LayerViewCreateErrorResult Class

The error result of a failed layerview-create event.

```csharp
public class LayerViewCreateErrorResult :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LayerViewCreateErrorResult

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[LayerViewCreateErrorResult](dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.html 'dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.LayerViewCreateErrorResult(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptException)'></a>

## LayerViewCreateErrorResult(Layer, JavascriptException) Constructor

The error result of a failed layerview-create event.

```csharp
public LayerViewCreateErrorResult(dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer, dymaptic.GeoBlazor.Core.Exceptions.JavascriptException Exception);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.LayerViewCreateErrorResult(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptException).Layer'></a>

`Layer` [Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')

The [Layer](dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.html#dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.Layer 'dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.Layer') that failed to be added to the view.

<a name='dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.LayerViewCreateErrorResult(dymaptic.GeoBlazor.Core.Components.Layers.Layer,dymaptic.GeoBlazor.Core.Exceptions.JavascriptException).Exception'></a>

`Exception` [JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')

The Javascript error wrapped in a .NET Exception.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.Exception'></a>

## LayerViewCreateErrorResult.Exception Property

The Javascript error wrapped in a .NET Exception.

```csharp
public dymaptic.GeoBlazor.Core.Exceptions.JavascriptException Exception { get; set; }
```

#### Property Value
[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')

<a name='dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.Layer'></a>

## LayerViewCreateErrorResult.Layer Property

The [Layer](dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.html#dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.Layer 'dymaptic.GeoBlazor.Core.Objects.LayerViewCreateErrorResult.Layer') that failed to be added to the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.Layer Layer { get; set; }
```

#### Property Value
[Layer](dymaptic.GeoBlazor.Core.Components.Layers.Layer.html 'dymaptic.GeoBlazor.Core.Components.Layers.Layer')
