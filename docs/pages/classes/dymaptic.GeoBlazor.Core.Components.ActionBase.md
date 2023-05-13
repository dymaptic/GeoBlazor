---
layout: default
title: ActionBase
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components](index.html#dymaptic.GeoBlazor.Core.Components 'dymaptic.GeoBlazor.Core.Components')

## ActionBase Class

Actions are customizable behavior which can be executed in certain widgets such as Popups, a BasemapLayerList, or a  
LayerList.  
<a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html">  
    ArcGIS  
    JS API  
</a>

```csharp
public abstract class ActionBase : dymaptic.GeoBlazor.Core.Components.MapComponent,
System.IEquatable<dymaptic.GeoBlazor.Core.Components.ActionBase>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MapComponent](dymaptic.GeoBlazor.Core.Components.MapComponent.html 'dymaptic.GeoBlazor.Core.Components.MapComponent') &#129106; ActionBase

Derived  
&#8627; [ActionButton](dymaptic.GeoBlazor.Core.Components.ActionButton.html 'dymaptic.GeoBlazor.Core.Components.ActionButton')  
&#8627; [ActionToggle](dymaptic.GeoBlazor.Core.Components.ActionToggle.html 'dymaptic.GeoBlazor.Core.Components.ActionToggle')

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Active'></a>

## ActionBase.Active Property

Set this property to true to display a spinner icon. You should do this if the action executes an async operation,  
such as a query, that requires letting the end user know that a process is ongoing in the background. Set the  
property back to false to communicate to the user that the process has finished.

```csharp
public System.Nullable<bool> Active { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.CallbackFunction'></a>

## ActionBase.CallbackFunction Property

The action function to perform on click.

```csharp
public System.Func<System.Threading.Tasks.Task>? CallbackFunction { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.ClassName'></a>

## ActionBase.ClassName Property

This adds a CSS class to the ActionButton's node.

```csharp
public string? ClassName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Disabled'></a>

## ActionBase.Disabled Property

Indicates whether this action is disabled.

```csharp
public System.Nullable<bool> Disabled { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Id'></a>

## ActionBase.Id Property

The name of the ID assigned to this action.

```csharp
public string? Id { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Title'></a>

## ActionBase.Title Property

The title of the action.

```csharp
public string? Title { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Type'></a>

## ActionBase.Type Property

Specifies the type of action. Choose between "button" or "toggle".

```csharp
public virtual string Type { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Visible'></a>

## ActionBase.Visible Property

Indicates if the action is visible.

```csharp
public System.Nullable<bool> Visible { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')
### Methods

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Equals(object)'></a>

## ActionBase.Equals(object) Method

Determines whether the specified object is equal to the current object.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.Equals(object).obj'></a>

`obj` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

The object to compare with the current object.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the specified object  is equal to the current object; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.GetHashCode()'></a>

## ActionBase.GetHashCode() Method

Serves as the default hash function.

```csharp
public override int GetHashCode();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
A hash code for the current object.
### Operators

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.op_Equality(dymaptic.GeoBlazor.Core.Components.ActionBase,dymaptic.GeoBlazor.Core.Components.ActionBase)'></a>

## ActionBase.operator ==(ActionBase, ActionBase) Operator

Determines whether the specified [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase') is equal to the current [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase').

```csharp
public static bool operator ==(dymaptic.GeoBlazor.Core.Components.ActionBase? left, dymaptic.GeoBlazor.Core.Components.ActionBase? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.op_Equality(dymaptic.GeoBlazor.Core.Components.ActionBase,dymaptic.GeoBlazor.Core.Components.ActionBase).left'></a>

`left` [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.op_Equality(dymaptic.GeoBlazor.Core.Components.ActionBase,dymaptic.GeoBlazor.Core.Components.ActionBase).right'></a>

`right` [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.op_Inequality(dymaptic.GeoBlazor.Core.Components.ActionBase,dymaptic.GeoBlazor.Core.Components.ActionBase)'></a>

## ActionBase.operator !=(ActionBase, ActionBase) Operator

Determines whether the specified [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase') is not equal to the current [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase').

```csharp
public static bool operator !=(dymaptic.GeoBlazor.Core.Components.ActionBase? left, dymaptic.GeoBlazor.Core.Components.ActionBase? right);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.op_Inequality(dymaptic.GeoBlazor.Core.Components.ActionBase,dymaptic.GeoBlazor.Core.Components.ActionBase).left'></a>

`left` [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase')

<a name='dymaptic.GeoBlazor.Core.Components.ActionBase.op_Inequality(dymaptic.GeoBlazor.Core.Components.ActionBase,dymaptic.GeoBlazor.Core.Components.ActionBase).right'></a>

`right` [ActionBase](dymaptic.GeoBlazor.Core.Components.ActionBase.html 'dymaptic.GeoBlazor.Core.Components.ActionBase')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
