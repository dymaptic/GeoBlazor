---
layout: default
title: DomPointerEvent
parent: Classes
---
---
layout: default
title: DomPointerEvent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Events](index.html#dymaptic.GeoBlazor.Core.Events 'dymaptic.GeoBlazor.Core.Events')

## DomPointerEvent Class

Represents the native DOM pointer event that the ArcGIS event is built on top of.

```csharp
public class DomPointerEvent :
System.IEquatable<dymaptic.GeoBlazor.Core.Events.DomPointerEvent>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DomPointerEvent

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[DomPointerEvent](dymaptic.GeoBlazor.Core.Events.DomPointerEvent.html 'dymaptic.GeoBlazor.Core.Events.DomPointerEvent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_)'></a>

## DomPointerEvent(Nullable<long>, Nullable<double>, Nullable<double>, Nullable<double>, Nullable<double>, Nullable<double>, Nullable<double>, Nullable<double>, Nullable<PointerType>, Nullable<bool>, Nullable<bool>) Constructor

Represents the native DOM pointer event that the ArcGIS event is built on top of.

```csharp
public DomPointerEvent(System.Nullable<long> PointerId, System.Nullable<double> Width, System.Nullable<double> Height, System.Nullable<double> Pressure, System.Nullable<double> TangentialPressure, System.Nullable<double> TiltX, System.Nullable<double> TiltY, System.Nullable<double> Twist, System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType, System.Nullable<bool> IsPrimary, System.Nullable<bool> IsTrusted);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).PointerId'></a>

`PointerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

A unique identifier for the pointer causing the event.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).Width'></a>

`Width` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The width (magnitude on the X axis), in CSS pixels, of the contact geometry of the pointer.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).Height'></a>

`Height` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The height (magnitude on the Y axis), in CSS pixels, of the contact geometry of the pointer.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).Pressure'></a>

`Pressure` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The normalized pressure of the pointer input in the range 0 to 1, where 0 and 1 represent the minimum and maximum  
pressure the hardware is capable of detecting, respectively.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).TangentialPressure'></a>

`TangentialPressure` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The normalized tangential pressure of the pointer input (also known as barrel pressure or cylinder stress) in the  
range -1 to 1, where 0 is the neutral position of the control.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).TiltX'></a>

`TiltX` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The plane angle (in degrees, in the range of -90 to 90) between the Y–Z plane and the plane containing both the  
pointer (e.g. pen stylus) axis and the Y axis.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).TiltY'></a>

`TiltY` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The plane angle (in degrees, in the range of -90 to 90) between the X–Z plane and the plane containing both the  
pointer (e.g. pen stylus) axis and the X axis.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).Twist'></a>

`Twist` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The clockwise rotation of the pointer (e.g. pen stylus) around its major axis in degrees, with a value in the range  
0 to 359.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).PointerType'></a>

`PointerType` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates the device type that caused the event (mouse, pen, touch, etc.).

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).IsPrimary'></a>

`IsPrimary` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the pointer represents the primary pointer of this pointer type.

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.DomPointerEvent(System.Nullable_long_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_dymaptic.GeoBlazor.Core.Events.PointerType_,System.Nullable_bool_,System.Nullable_bool_).IsTrusted'></a>

`IsTrusted` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

Indicates if the event is trusted.
### Properties

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.Height'></a>

## DomPointerEvent.Height Property

The height (magnitude on the Y axis), in CSS pixels, of the contact geometry of the pointer.

```csharp
public System.Nullable<double> Height { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.IsPrimary'></a>

## DomPointerEvent.IsPrimary Property

Indicates if the pointer represents the primary pointer of this pointer type.

```csharp
public System.Nullable<bool> IsPrimary { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.IsTrusted'></a>

## DomPointerEvent.IsTrusted Property

Indicates if the event is trusted.

```csharp
public System.Nullable<bool> IsTrusted { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.PointerId'></a>

## DomPointerEvent.PointerId Property

A unique identifier for the pointer causing the event.

```csharp
public System.Nullable<long> PointerId { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.PointerType'></a>

## DomPointerEvent.PointerType Property

Indicates the device type that caused the event (mouse, pen, touch, etc.).

```csharp
public System.Nullable<dymaptic.GeoBlazor.Core.Events.PointerType> PointerType { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[PointerType](dymaptic.GeoBlazor.Core.Events.PointerType.html 'dymaptic.GeoBlazor.Core.Events.PointerType')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.Pressure'></a>

## DomPointerEvent.Pressure Property

The normalized pressure of the pointer input in the range 0 to 1, where 0 and 1 represent the minimum and maximum  
pressure the hardware is capable of detecting, respectively.

```csharp
public System.Nullable<double> Pressure { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.TangentialPressure'></a>

## DomPointerEvent.TangentialPressure Property

The normalized tangential pressure of the pointer input (also known as barrel pressure or cylinder stress) in the  
range -1 to 1, where 0 is the neutral position of the control.

```csharp
public System.Nullable<double> TangentialPressure { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.TiltX'></a>

## DomPointerEvent.TiltX Property

The plane angle (in degrees, in the range of -90 to 90) between the Y–Z plane and the plane containing both the  
pointer (e.g. pen stylus) axis and the Y axis.

```csharp
public System.Nullable<double> TiltX { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.TiltY'></a>

## DomPointerEvent.TiltY Property

The plane angle (in degrees, in the range of -90 to 90) between the X–Z plane and the plane containing both the  
pointer (e.g. pen stylus) axis and the X axis.

```csharp
public System.Nullable<double> TiltY { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.Twist'></a>

## DomPointerEvent.Twist Property

The clockwise rotation of the pointer (e.g. pen stylus) around its major axis in degrees, with a value in the range  
0 to 359.

```csharp
public System.Nullable<double> Twist { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='dymaptic.GeoBlazor.Core.Events.DomPointerEvent.Width'></a>

## DomPointerEvent.Width Property

The width (magnitude on the X axis), in CSS pixels, of the contact geometry of the pointer.

```csharp
public System.Nullable<double> Width { get; set; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

