---
layout: default
title: AbortManagerResult
parent: Classes
---
---
layout: default
title: AbortManagerResult
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## AbortManagerResult Class

The result of creating an abort controller and signal.

```csharp
public class AbortManagerResult :
System.IEquatable<dymaptic.GeoBlazor.Core.Objects.AbortManagerResult>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbortManagerResult

Implements [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[AbortManagerResult](dymaptic.GeoBlazor.Core.Objects.AbortManagerResult.html 'dymaptic.GeoBlazor.Core.Objects.AbortManagerResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManagerResult.AbortManagerResult(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference)'></a>

## AbortManagerResult(IJSObjectReference, IJSObjectReference) Constructor

The result of creating an abort controller and signal.

```csharp
public AbortManagerResult(Microsoft.JSInterop.IJSObjectReference AbortControllerRef, Microsoft.JSInterop.IJSObjectReference AbortSignalRef);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManagerResult.AbortManagerResult(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference).AbortControllerRef'></a>

`AbortControllerRef` [Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

Reference to the JavaScript abort controller.

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManagerResult.AbortManagerResult(Microsoft.JSInterop.IJSObjectReference,Microsoft.JSInterop.IJSObjectReference).AbortSignalRef'></a>

`AbortSignalRef` [Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

Reference to the JavaScript abort signal.
### Properties

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManagerResult.AbortControllerRef'></a>

## AbortManagerResult.AbortControllerRef Property

Reference to the JavaScript abort controller.

```csharp
public Microsoft.JSInterop.IJSObjectReference AbortControllerRef { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManagerResult.AbortSignalRef'></a>

## AbortManagerResult.AbortSignalRef Property

Reference to the JavaScript abort signal.

```csharp
public Microsoft.JSInterop.IJSObjectReference AbortSignalRef { get; set; }
```

#### Property Value
[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')

