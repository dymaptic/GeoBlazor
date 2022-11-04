---
layout: default
title: ResizeEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## ResizeEvent Class

Result of the view.on('resize') event

```csharp
public class ResizeEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.ResizeEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ResizeEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[ResizeEvent](dymaptic.GeoBlazor.Core.Objects.ResizeEvent.html 'dymaptic.GeoBlazor.Core.Objects.ResizeEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.ResizeEvent(double,double,double,double)'></a>

## ResizeEvent(double, double, double, double) Constructor

Result of the view.on('resize') event

```csharp
public ResizeEvent(double OldWidth, double OldHeight, double Width, double Height);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.ResizeEvent(double,double,double,double).OldWidth'></a>

`OldWidth` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The previous view width in pixels

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.ResizeEvent(double,double,double,double).OldHeight'></a>

`OldHeight` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The previous view height in pixels

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.ResizeEvent(double,double,double,double).Width'></a>

`Width` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The new measured view width in pixels

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.ResizeEvent(double,double,double,double).Height'></a>

`Height` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

The new measured view height in pixels
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.Height'></a>

## ResizeEvent.Height Property

The new measured view height in pixels

```csharp
public double Height { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.OldHeight'></a>

## ResizeEvent.OldHeight Property

The previous view height in pixels

```csharp
public double OldHeight { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.OldWidth'></a>

## ResizeEvent.OldWidth Property

The previous view width in pixels

```csharp
public double OldWidth { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='dymaptic.GeoBlazor.Core.Objects.ResizeEvent.Width'></a>

## ResizeEvent.Width Property

The new measured view width in pixels

```csharp
public double Width { get; set; }
```

#### Property Value
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')
