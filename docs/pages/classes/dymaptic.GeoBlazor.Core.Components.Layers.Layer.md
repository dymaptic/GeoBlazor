---
layout: default
title: Layer
parent: Classes
---
---
layout: default
title: Layer
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## Layer Class

The layer is the most fundamental component of a Map. It is a collection of spatial data in the form of vector  
graphics or raster images that represent real-world phenomena. Layers may contain discrete features that store  
vector data or continuous cells/pixels that store raster data.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public abstract class Layer : dymaptic.GeoBlazor.Core.Components.MapComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; Layer

Derived  
&#8627; [ElevationLayer](dymaptic.GeoBlazor.Core.Components.Layers.ElevationLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.ElevationLayer')  
&#8627; [FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer')  
&#8627; [GeoJSONLayer](dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer')  
&#8627; [GeoRSSLayer](dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GeoRSSLayer')  
&#8627; [GraphicsLayer](dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer')  
&#8627; [TileLayer](dymaptic.GeoBlazor.Core.Components.Layers.TileLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.TileLayer')  
&#8627; [WebTileLayer](dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.AbortManager'></a>

## Layer.AbortManager Property

Handles conversion from .NET CancellationToken to JavaScript AbortController

```csharp
public dymaptic.GeoBlazor.Core.Objects.AbortManager? AbortManager { get; set; }
```

#### Property Value
[AbortManager](dymaptic.GeoBlazor.Core.Objects.AbortManager.html 'dymaptic.GeoBlazor.Core.Objects.AbortManager')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.FullExtent'></a>

## Layer.FullExtent Property

The full extent of the layer. By default, this is worldwide. This property may be used to set the extent of the  
view to match a layer's extent so that its features appear to fill the view.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Extent? FullExtent { get; set; }
```

#### Property Value
[Extent](dymaptic.GeoBlazor.Core.Components.Geometries.Extent.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Extent')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Imported'></a>

## Layer.Imported Property

Marks an incoming layer loaded from a service or Javascript source.

```csharp
public bool Imported { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.JsLayerReference'></a>

## Layer.JsLayerReference Property

The JavaScript object that represents the layer.

```csharp
public Microsoft.JSInterop.IJSObjectReference? JsLayerReference { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.LayerType'></a>

## Layer.LayerType Property

Used internally to identify the sub type of Layer

```csharp
public virtual string LayerType { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.LayerView'></a>

## Layer.LayerView Property

Represents the view for a single layer after it has been added to either a MapView or a SceneView.

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LayerView? LayerView { get; set; }
```

#### Property Value
[LayerView](dymaptic.GeoBlazor.Core.Components.Layers.LayerView.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerView')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.ListMode'></a>

## Layer.ListMode Property

Indicates how the layer should display in the LayerList widget. The possible values are listed below.

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Components.Layers.ListMode> ListMode { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[ListMode](dymaptic.GeoBlazor.Core.Components.Layers.ListMode.html 'dymaptic.GeoBlazor.Core.Components.Layers.ListMode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Opacity'></a>

## Layer.Opacity Property

The opacity of the layer.

```csharp
public System.Nullable<double> Opacity { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Title'></a>

## Layer.Title Property

The title of the layer used to identify it in places such as the Legend and LayerList widgets.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Visible'></a>

## Layer.Visible Property

Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is  
referenced in a view, but its features will not be visible in the view.

```csharp
public System.Nullable<bool> Visible { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.DisposeAsync()'></a>

## Layer.DisposeAsync() Method

Implements the `IAsyncDisposable` pattern.

```csharp
public override System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Load(System.Threading.CancellationToken)'></a>

## Layer.Load(CancellationToken) Method

Loads the resources referenced by this class. This method automatically executes for a View and all of the  
resources it references in Map if the view is constructed with a map instance.  
This method must be called by the developer when accessing a resource that will not be loaded in a View.  
The load() method only triggers the loading of the resource the first time it is called. The subsequent calls  
return the same promise.

```csharp
public System.Threading.Tasks.Task Load(System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.Load(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

### Remarks
It's possible to provide a signal to stop being interested into a Loadable instance load status. When the signal is  
aborted, the instance does not stop its loading process, only cancelLoad can abort it.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Layer.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Layer.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Layer.ValidateRequiredChildren()'></a>

## Layer.ValidateRequiredChildren() Method

When a [MapView](dymaptic.GeoBlazor.Core.Components.Views.MapView.html 'dymaptic.GeoBlazor.Core.Components.Views.MapView') is prepared to render, this will check to make sure that all properties with the  
[RequiredPropertyAttribute](dymaptic.GeoBlazor.Core.RequiredPropertyAttribute.html 'dymaptic.GeoBlazor.Core.RequiredPropertyAttribute') are provided.

```csharp
public override void ValidateRequiredChildren();
```

#### Exceptions

[MissingRequiredChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredChildElementException')  
The consumer needs to provide the missing child component

[MissingRequiredOptionsChildElementException](dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.MissingRequiredOptionsChildElementException')  
The consumer needs to provide ONE of the options of child components

