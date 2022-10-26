---
layout: default
title: SimpleFillSymbol
parent: Classes
---
---
layout: default
title: SimpleFillSymbol
parent: Classes
---
---
layout: default
title: SimpleFillSymbol
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Symbols](index.html#dymaptic.GeoBlazor.Core.Components.Symbols 'dymaptic.GeoBlazor.Core.Components.Symbols')

## SimpleFillSymbol Class

SimpleFillSymbol is used for rendering 2D polygons in either a MapView or a SceneView. It can be filled with a solid color, or a pattern. In addition, the symbol can have an optional outline, which is defined by a SimpleLineSymbol.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleFillSymbol.html">ArcGIS JS API</a>

```csharp
public class SimpleFillSymbol : dymaptic.GeoBlazor.Core.Components.Symbols.FillSymbol
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') &#129106; [FillSymbol](dymaptic.GeoBlazor.Core.Components.Symbols.FillSymbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.FillSymbol') &#129106; SimpleFillSymbol
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.FillStyle'></a>

## SimpleFillSymbol.FillStyle Property

The fill style.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Symbols.FillStyle> FillStyle { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[FillStyle](dymaptic.GeoBlazor.Core.Components.Symbols.FillStyle.html 'dymaptic.GeoBlazor.Core.Components.Symbols.FillStyle')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.Outline'></a>

## SimpleFillSymbol.Outline Property

The outline of the polygon.

```csharp
public dymaptic.GeoBlazor.Core.Components.Symbols.Outline? Outline { get; set; }
```

#### Property Value
[Outline](dymaptic.GeoBlazor.Core.Components.Symbols.Outline.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Outline')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.Type'></a>

## SimpleFillSymbol.Type Property

The symbol type

```csharp
public override string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SimpleFillSymbol.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync#dymaptic_GeoBlazor_Core_Components_MapComponent_OnAfterRenderAsync_System_Boolean_ 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnAfterRenderAsync(System.Boolean)') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## SimpleFillSymbol.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.ValidateRequiredChildren()'></a>

## SimpleFillSymbol.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the [RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components


