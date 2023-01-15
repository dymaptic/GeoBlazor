---
layout: default
title: AbortManager
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Objects](index.html#dymaptic.GeoBlazor.Core.Objects 'dymaptic.GeoBlazor.Core.Objects')

## AbortManager Class

The AbortManager translates a .NET [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') into a JavaScript abort signal.

```csharp
public class AbortManager :
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbortManager

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManager.AbortManager(Microsoft.JSInterop.IJSRuntime)'></a>

## AbortManager(IJSRuntime) Constructor

Creates a new AbortManager.

```csharp
public AbortManager(Microsoft.JSInterop.IJSRuntime jsRuntime);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManager.AbortManager(Microsoft.JSInterop.IJSRuntime).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

The [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime') to use for JavaScript interop.
### Methods

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManager.CreateAbortSignal(System.Threading.CancellationToken)'></a>

## AbortManager.CreateAbortSignal(CancellationToken) Method

Creates a new abort signal for the given [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken').

```csharp
public System.Threading.Tasks.Task<Microsoft.JSInterop.IJSObjectReference> CreateAbortSignal(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManager.CreateAbortSignal(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to create the abort signal for.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[Microsoft.JSInterop.IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSObjectReference 'Microsoft.JSInterop.IJSObjectReference')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks
Uses of this method should always be followed by [DisposeAbortController(CancellationToken)](dymaptic.GeoBlazor.Core.Objects.AbortManager.html#dymaptic.GeoBlazor.Core.Objects.AbortManager.DisposeAbortController(System.Threading.CancellationToken) 'dymaptic.GeoBlazor.Core.Objects.AbortManager.DisposeAbortController(System.Threading.CancellationToken)') when you are finished with the JavaScript calls.

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManager.DisposeAbortController(System.Threading.CancellationToken)'></a>

## AbortManager.DisposeAbortController(CancellationToken) Method

Disposes the signal created for a specific JavaScript call, this should always be called when you are done with the signal.

```csharp
public System.Threading.Tasks.Task DisposeAbortController(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManager.DisposeAbortController(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken') to abort the query for.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='dymaptic.GeoBlazor.Core.Objects.AbortManager.DisposeAsync()'></a>

## AbortManager.DisposeAsync() Method

Disposes the full AbortManager, and cancels all queries.

```csharp
public System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')
