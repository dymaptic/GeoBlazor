---
layout: default
title: MouseWheelResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## MouseWheelResult Class

Result of the view.on('mouse-wheel') event

```csharp
public class MouseWheelResult :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.MouseWheelResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MouseWheelResult

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[MouseWheelResult](dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.html 'dymaptic.GeoBlazor.Core.Objects.MouseWheelResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.MouseWheelResult(double,double,double)'></a>

## MouseWheelResult(double, double, double) Constructor

Result of the view.on('mouse-wheel') event

```csharp
public MouseWheelResult(double X, double Y, double DeltaY);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.MouseWheelResult(double,double,double).X'></a>

`X` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The horizontal screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.MouseWheelResult(double,double,double).Y'></a>

`Y` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The vertical screen coordinate of the click on the view.

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.MouseWheelResult(double,double,double).DeltaY'></a>

`DeltaY` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Number representing the vertical scroll amount.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.DeltaY'></a>

## MouseWheelResult.DeltaY Property

Number representing the vertical scroll amount.

```csharp
public double DeltaY { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.X'></a>

## MouseWheelResult.X Property

The horizontal screen coordinate of the click on the view.

```csharp
public double X { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.MouseWheelResult.Y'></a>

## MouseWheelResult.Y Property

The vertical screen coordinate of the click on the view.

```csharp
public double Y { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
