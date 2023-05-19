---
layout: default
title: Graphic
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## Graphic Class

A Graphic is a vector representation of real world geographic phenomena. It can contain geometry, a symbol, and  
attributes. A Graphic is displayed in the GraphicsLayer.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">  
    ArcGIS JS  
    API  
</a>

```csharp
public class Graphic : dymaptic.GeoBlazor.Core.Components.Layers.LayerObject,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Layers.Graphic>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [LayerObject](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject') &#129106; Graphic

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Graphic()'></a>

## Graphic() Constructor

Parameterless constructor for using as a razor component

```csharp
public Graphic();
```

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Graphic(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary)'></a>

## Graphic(Geometry, Symbol, PopupTemplate, AttributesDictionary) Constructor

Constructs a new Graphic in code with parameters

```csharp
public Graphic(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? geometry=null, dymaptic.GeoBlazor.Core.Components.Symbols.Symbol? symbol=null, dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate? popupTemplate=null, dymaptic.GeoBlazor.Core.Objects.AttributesDictionary? attributes=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Graphic(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

The geometry that defines the graphic's location.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Graphic(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).symbol'></a>

`symbol` [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

The [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol') for the object.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Graphic(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).popupTemplate'></a>

`popupTemplate` [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')

The [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate') for displaying content in a Popup when the graphic is selected.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Graphic(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry,dymaptic.GeoBlazor.Core.Components.Symbols.Symbol,dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate,dymaptic.GeoBlazor.Core.Objects.AttributesDictionary).attributes'></a>

`attributes` [AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

Name-value pairs of fields and field values associated with the graphic.
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Attributes'></a>

## Graphic.Attributes Property

Name-value pairs of fields and field values associated with the graphic.

```csharp
public dymaptic.GeoBlazor.Core.Objects.AttributesDictionary Attributes { get; set; }
```

#### Property Value
[AttributesDictionary](dymaptic.GeoBlazor.Core.Objects.AttributesDictionary.html 'dymaptic.GeoBlazor.Core.Objects.AttributesDictionary')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry'></a>

## Graphic.Geometry Property

The geometry that defines the graphic's location.

```csharp
public dymaptic.GeoBlazor.Core.Components.Geometries.Geometry? Geometry { get; set; }
```

#### Property Value
[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

### Remarks
To retrieve a current geometry for a graphic, use [GetGeometry()](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetGeometry() 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetGeometry()') instead of calling this Property  
directly.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.LayerId'></a>

## Graphic.LayerId Property

The GeoBlazor Id of the parent layer, used when serializing the graphic to/from JavaScript.

```csharp
public System.Nullable<System.Guid> LayerId { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Guid](https://docs.microsoft.com/en-us/dotnet/api/System.Guid 'System.Guid')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate'></a>

## Graphic.PopupTemplate Property

The [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate') for displaying content in a Popup when the graphic is selected.

```csharp
public dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate? PopupTemplate { get; set; }
```

#### Property Value
[PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')

### Remarks
To retrieve a current popup template for a graphic, use [GetPopupTemplate()](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetPopupTemplate() 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetPopupTemplate()') instead of calling this  
Property directly.
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.DisposeAsync()'></a>

## Graphic.DisposeAsync() Method

Implements the `IAsyncDisposable` pattern.

```csharp
public override System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Equals(object)'></a>

## Graphic.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetGeometry()'></a>

## Graphic.GetGeometry() Method

Retrieves the [Geometry](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry') from the rendered graphic.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Geometries.Geometry?> GetGeometry();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetHashCode()'></a>

## Graphic.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetPopupTemplate()'></a>

## Graphic.GetPopupTemplate() Method

Retrieves the [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate') from the rendered graphic.

```csharp
public System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate?> GetPopupTemplate();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.GetSymbol()'></a>

## Graphic.GetSymbol() Method

Gets the current [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') for the object.

```csharp
public override System.Threading.Tasks.Task<dymaptic.GeoBlazor.Core.Components.Symbols.Symbol?> GetSymbol();
```

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Graphic.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetGeometry(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry)'></a>

## Graphic.SetGeometry(Geometry) Method

Sets the [Geometry](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.Geometry') on the rendered graphic.

```csharp
public System.Threading.Tasks.Task SetGeometry(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry geometry);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetGeometry(dymaptic.GeoBlazor.Core.Components.Geometries.Geometry).geometry'></a>

`geometry` [Geometry](dymaptic.GeoBlazor.Core.Components.Geometries.Geometry.html 'dymaptic.GeoBlazor.Core.Components.Geometries.Geometry')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)'></a>

## Graphic.SetParametersAsync(ParameterView) Method

Sets parameters supplied by the component's parent in the render tree.

```csharp
public override System.Threading.Tasks.Task SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView parameters);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView).parameters'></a>

`parameters` [Microsoft.AspNetCore.Components.ParameterView](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ParameterView 'Microsoft.AspNetCore.Components.ParameterView')

The parameters.

Implements [SetParametersAsync(ParameterView)](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.IComponent.SetParametersAsync#Microsoft_AspNetCore_Components_IComponent_SetParametersAsync_Microsoft_AspNetCore_Components_ParameterView_ 'Microsoft.AspNetCore.Components.IComponent.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
A [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') that completes when the component has finished updating and rendering itself.

### Remarks
  
Parameters are passed when [Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync#Microsoft_AspNetCore_Components_ComponentBase_SetParametersAsync_Microsoft_AspNetCore_Components_ParameterView_ 'Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)') is called. It is not required that  
the caller supply a parameter value for all of the parameters that are logically understood by the component.  
  
The default implementation of [Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync#Microsoft_AspNetCore_Components_ComponentBase_SetParametersAsync_Microsoft_AspNetCore_Components_ParameterView_ 'Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)') will set the value of each property  
decorated with [Microsoft.AspNetCore.Components.ParameterAttribute](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ParameterAttribute 'Microsoft.AspNetCore.Components.ParameterAttribute') or [Microsoft.AspNetCore.Components.CascadingParameterAttribute](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.CascadingParameterAttribute 'Microsoft.AspNetCore.Components.CascadingParameterAttribute') that has  
a corresponding value in the [Microsoft.AspNetCore.Components.ParameterView](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ParameterView 'Microsoft.AspNetCore.Components.ParameterView'). Parameters that do not have a corresponding value  
will be unchanged.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetPopupTemplate(dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate)'></a>

## Graphic.SetPopupTemplate(PopupTemplate) Method

Sets the [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate') on the rendered graphic.

```csharp
public System.Threading.Tasks.Task SetPopupTemplate(dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate popupTemplate);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetPopupTemplate(dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate).popupTemplate'></a>

`popupTemplate` [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate.html 'dymaptic.GeoBlazor.Core.Components.Popups.PopupTemplate')

The [PopupTemplate](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html#dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic.PopupTemplate') for displaying content in a Popup when the graphic is selected.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol)'></a>

## Graphic.SetSymbol(Symbol) Method

Sets the [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') for the object.

```csharp
public override System.Threading.Tasks.Task SetSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol symbol);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.SetSymbol(dymaptic.GeoBlazor.Core.Components.Symbols.Symbol).symbol'></a>

`symbol` [Symbol](dymaptic.GeoBlazor.Core.Components.Symbols.Symbol.html 'dymaptic.GeoBlazor.Core.Components.Symbols.Symbol')

The [Symbol](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html#dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.Symbol') for the object.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Graphic.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.op_Equality(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## Graphic.operator ==(Graphic, Graphic) Operator

Compares two [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') instances for equality.

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Layers.Graphic? left, dymaptic.GeoBlazor.Core.Components.Layers.Graphic? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.op_Equality(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Layers.Graphic).left'></a>

`left` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.op_Equality(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Layers.Graphic).right'></a>

`right` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.op_Inequality(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Layers.Graphic)'></a>

## Graphic.operator !=(Graphic, Graphic) Operator

Compares two [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic') instances for inequality.

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Layers.Graphic? left, dymaptic.GeoBlazor.Core.Components.Layers.Graphic? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.op_Inequality(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Layers.Graphic).left'></a>

`left` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Graphic.op_Inequality(dymaptic.GeoBlazor.Core.Components.Layers.Graphic,dymaptic.GeoBlazor.Core.Components.Layers.Graphic).right'></a>

`right` [Graphic](dymaptic.GeoBlazor.Core.Components.Layers.Graphic.html 'dymaptic.GeoBlazor.Core.Components.Layers.Graphic')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
