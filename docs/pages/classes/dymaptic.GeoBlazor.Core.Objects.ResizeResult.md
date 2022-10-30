---
layout: default
title: ResizeResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## ResizeResult Class

Result of the view.on('resize') event

```csharp
public class ResizeResult :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.ResizeResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ResizeResult

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ResizeResult](dymaptic.GeoBlazor.Core.Objects.ResizeResult.html 'dymaptic.GeoBlazor.Core.Objects.ResizeResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.ResizeResult(double,double,double,double)'></a>

## ResizeResult(double, double, double, double) Constructor

Result of the view.on('resize') event

```csharp
public ResizeResult(double OldWidth, double OldHeight, double Width, double Height);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.ResizeResult(double,double,double,double).OldWidth'></a>

`OldWidth` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The previous view width in pixels

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.ResizeResult(double,double,double,double).OldHeight'></a>

`OldHeight` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The previous view height in pixels

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.ResizeResult(double,double,double,double).Width'></a>

`Width` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The new measured view width in pixels

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.ResizeResult(double,double,double,double).Height'></a>

`Height` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The new measured view height in pixels
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.Height'></a>

## ResizeResult.Height Property

The new measured view height in pixels

```csharp
public double Height { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.OldHeight'></a>

## ResizeResult.OldHeight Property

The previous view height in pixels

```csharp
public double OldHeight { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.OldWidth'></a>

## ResizeResult.OldWidth Property

The previous view width in pixels

```csharp
public double OldWidth { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeResult.Width'></a>

## ResizeResult.Width Property

The new measured view width in pixels

```csharp
public double Width { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
