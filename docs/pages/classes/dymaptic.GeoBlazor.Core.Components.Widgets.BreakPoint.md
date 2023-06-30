---
layout: default
title: BreakPoint
parent: Classes
---
---
layout: default
title: BreakPoint
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Components.Widgets](index.html#dymaptic.GeoBlazor.Core.Components.Widgets 'dymaptic.GeoBlazor.Core.Components.Widgets')

## BreakPoint Class

Defines the dimensions of the View at which to dock the popup. Set to false to disable docking at a breakpoint.  
DefaultValue: true

```csharp
public class BreakPoint
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BreakPoint
### Constructors

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.BreakPoint(bool)'></a>

## BreakPoint(bool) Constructor

Constructor for building a breakpoint with default max width and height.

```csharp
public BreakPoint(bool value);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.BreakPoint(bool).value'></a>

`value` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Determines if the breakpoint is on or off.

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.BreakPoint(System.Nullable_double_,System.Nullable_double_)'></a>

## BreakPoint(Nullable<double>, Nullable<double>) Constructor

Constructor for building a breakpoint with specified max width and/or height.

```csharp
public BreakPoint(System.Nullable<double> width=null, System.Nullable<double> height=null);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.BreakPoint(System.Nullable_double_,System.Nullable_double_).width'></a>

`width` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The maximum width of the View at which the popup will be set to dockEnabled automatically.  
DefaultValue: 544

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.BreakPoint(System.Nullable_double_,System.Nullable_double_).height'></a>

`height` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The maximum height of the View at which the popup will be set to dockEnabled automatically.  
DefaultValue: 544
### Properties

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.BoolValue'></a>

## BreakPoint.BoolValue Property

Determines if the breakpoint is on or off.

```csharp
public System.Nullable<bool> BoolValue { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.Height'></a>

## BreakPoint.Height Property

The maximum height of the View at which the popup will be set to dockEnabled automatically.  
DefaultValue: 544

```csharp
public System.Nullable<double> Height { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Components.Widgets.BreakPoint.Width'></a>

## BreakPoint.Width Property

The maximum width of the View at which the popup will be set to dockEnabled automatically.  
DefaultValue: 544

```csharp
public System.Nullable<double> Width { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

