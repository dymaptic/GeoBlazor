---
layout: default
title: Label
parent: Classes
---
---
layout: default
title: Label
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Layers](index.html#dymaptic.GeoBlazor.Core.Components.Layers 'dymaptic.GeoBlazor.Core.Components.Layers')

## Label Class

Defines label expressions, symbols, scale ranges, label priorities, and label placement options for labels on a  
layer. See the Labeling guide for more information about labeling.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public class Label : dymaptic.GeoBlazor.Core.Components.Layers.LayerObject,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.Layers.Label>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; [LayerObject](dymaptic.GeoBlazor.Core.Components.Layers.LayerObject.html 'dymaptic.GeoBlazor.Core.Components.Layers.LayerObject') &#129106; Label

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.LabelExpression'></a>

## Label.LabelExpression Property

Defines the labels for a MapImageLayer.

```csharp
public string? LabelExpression { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks
MapImageLayer not yet implemented in GeoBlazor

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.LabelExpressionInfo'></a>

## Label.LabelExpressionInfo Property

Defines the labels for a [FeatureLayer](dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer.html 'dymaptic.GeoBlazor.Core.Components.Layers.FeatureLayer').

```csharp
public dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo? LabelExpressionInfo { get; set; }
```

#### Property Value
[LabelExpressionInfo](dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo.html 'dymaptic.GeoBlazor.Core.Components.Layers.LabelExpressionInfo')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.LabelPlacement'></a>

## Label.LabelPlacement Property

The position of the label.

```csharp
public string? LabelPlacement { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.Equals(object)'></a>

## Label.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.GetHashCode()'></a>

## Label.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Label.RegisterChildComponent(MapComponent) Method

Called from [dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync](https://docs.microsoft.com/en-us/dotnet/api/dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync 'dymaptic.GeoBlazor.Core.Components.MapComponent.OnInitializedAsync') to "Register" the current component with it's parent.

```csharp
public override System.Threading.Tasks.Task RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.RegisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The calling, child component to register

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

#### Exceptions

[InvalidChildElementException](dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException.html 'dymaptic.GeoBlazor.Core.Exceptions.InvalidChildElementException')  
Throws if the current child is not a valid sub-component to the parent.

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent)'></a>

## Label.UnregisterChildComponent(MapComponent) Method

Undoes the "Registration" of a child with its parent.

```csharp
public override System.Threading.Tasks.Task UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent child);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.UnregisterChildComponent(dymaptic.GeoBlazor.Core.Components.MapComponent).child'></a>

`child` [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent')

The child to unregister

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.ValidateRequiredChildren()'></a>

## Label.ValidateRequiredChildren() Method

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
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.op_Equality(dymaptic.GeoBlazor.Core.Components.Layers.Label,dymaptic.GeoBlazor.Core.Components.Layers.Label)'></a>

## Label.operator ==(Label, Label) Operator

Compares two [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')s for equality.

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.Layers.Label? left, dymaptic.GeoBlazor.Core.Components.Layers.Label? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.op_Equality(dymaptic.GeoBlazor.Core.Components.Layers.Label,dymaptic.GeoBlazor.Core.Components.Layers.Label).left'></a>

`left` [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.op_Equality(dymaptic.GeoBlazor.Core.Components.Layers.Label,dymaptic.GeoBlazor.Core.Components.Layers.Label).right'></a>

`right` [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.op_Inequality(dymaptic.GeoBlazor.Core.Components.Layers.Label,dymaptic.GeoBlazor.Core.Components.Layers.Label)'></a>

## Label.operator !=(Label, Label) Operator

Compares two [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')s for inequality.

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.Layers.Label? left, dymaptic.GeoBlazor.Core.Components.Layers.Label? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.op_Inequality(dymaptic.GeoBlazor.Core.Components.Layers.Label,dymaptic.GeoBlazor.Core.Components.Layers.Label).left'></a>

`left` [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')

<a name='dymaptic.GeoBlazor.Core.Components.Layers.Label.op_Inequality(dymaptic.GeoBlazor.Core.Components.Layers.Label,dymaptic.GeoBlazor.Core.Components.Layers.Label).right'></a>

`right` [Label](dymaptic.GeoBlazor.Core.Components.Layers.Label.html 'dymaptic.GeoBlazor.Core.Components.Layers.Label')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

