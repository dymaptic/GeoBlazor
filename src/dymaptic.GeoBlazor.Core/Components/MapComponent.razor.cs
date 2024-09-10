﻿using dymaptic.GeoBlazor.Core.Components.Views;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The abstract base Razor Component class that all GeoBlazor components derive from.
/// </summary>
[JsonConverter(typeof(MapComponentConverter))]
public abstract partial class MapComponent : ComponentBase, IAsyncDisposable
{
    /// <summary>
    ///     Represents an instance of a JavaScript runtime to which calls may be dispatched.
    /// </summary>
    [Inject]
    [JsonIgnore]
    public IJSRuntime JsRuntime { get; set; } = default!;

    /// <summary>
    ///     ChildContent defines the ability to add other components within this component in the razor syntax.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    ///     The parent MapComponent of this component.
    /// </summary>
    [CascadingParameter(Name = "Parent")]
    [JsonIgnore]
    public MapComponent? Parent { get; set; }

    /// <summary>
    ///     A boolean flag that indicates that the current <see cref="MapView" /> has finished rendering.
    ///     To listen for a map rendering event, use <see cref="MapView.OnViewRendered" />.
    /// </summary>
    [CascadingParameter(Name = "MapRendered")]
    [JsonIgnore]
    public bool MapRendered { get; set; }

    /// <summary>
    ///     The reference to arcGisJsInterop.ts from .NET
    /// </summary>
    [CascadingParameter(Name = "JsModule")]
    [JsonIgnore]
    public IJSObjectReference? JsModule { get; set; }
    
    /// <summary>
    ///     Optional JsModule for GeoBlazor Pro
    /// </summary>
    [CascadingParameter(Name = "ProJsModule")]
    [JsonIgnore]
    public IJSObjectReference? ProJsModule { get; set; }

    /// <summary>
    ///     The parent <see cref="MapView" /> of the current component.
    /// </summary>
    [CascadingParameter(Name = "View")]
    [JsonIgnore]
    public MapView? View { get; set; }
    
    /// <summary>
    ///     Indicates the visibility of the component. Default value: true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Visible { get; set; }

    /// <summary>
    ///     A unique identifier, used to track components across .NET and JavaScript.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();
    
    /// <summary>
    ///     Extension properties for GeoBlazor Pro
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object?>? ProProperties { get; set; }

    /// <summary>
    ///     Implements the `IAsyncDisposable` pattern.
    /// </summary>
    public virtual async ValueTask DisposeAsync()
    {
        if (Parent is not null && _registered)
        {
            await Parent.UnregisterChildComponent(this);
            _registered = false;
        }

        foreach ((Delegate Handler, IJSObjectReference JsObjRef) tuple in _watchers.Values)
        {
            IJSObjectReference jsRef = tuple.JsObjRef;
            await jsRef.InvokeVoidAsync("remove");
        }

        _watchers.Clear();

        foreach ((Delegate Handler, IJSObjectReference JsObjRef) tuple in _listeners.Values)
        {
            IJSObjectReference jsRef = tuple.JsObjRef;
            await jsRef.InvokeVoidAsync("remove");
        }

        _listeners.Clear();

        foreach ((Delegate Handler, IJSObjectReference JsObjRef) tuple in _waiters.Values)
        {
            IJSObjectReference jsRef = tuple.JsObjRef;
            await jsRef.InvokeVoidAsync("remove");
        }

        _waiters.Clear();

        if (JsModule is not null)
        {
            try
            {
                await JsModule.InvokeVoidAsync("disposeMapComponent", Id, View?.Id);
            }
            catch (JSDisconnectedException)
            {
                // it's fine
            }
        }

        CancellationTokenSource.Cancel();
    }

    /// <summary>
    ///     Add a child component programmatically. Calls <see cref="RegisterChildComponent" /> internally.
    /// </summary>
    /// <param name="child">
    ///     The child component to add
    /// </param>
    public Task Add(MapComponent child)
    {
        return RegisterChildComponent(child);
    }

    /// <summary>
    ///     Called from <see cref="MapComponent.OnInitializedAsync" /> to "Register" the current component with it's parent.
    /// </summary>
    /// <param name="child">
    ///     The calling, child component to register
    /// </param>
    /// <exception cref="InvalidChildElementException">
    ///     Throws if the current child is not a valid sub-component to the parent.
    /// </exception>
    /// <remarks>
    ///     This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method. If you see no other way to register a child component, please open an issue on GitHub.
    /// </remarks>
    public virtual async Task RegisterChildComponent(MapComponent child)
    {
        try
        {
            Assembly proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
            _proExtensions ??= proAssembly.GetType("dymaptic.GeoBlazor.Pro.ProExtensions");
            MethodInfo? method = _proExtensions?.GetMethod("RegisterProChildComponent");

            if (method is not null)
            {
                await (Task)method.Invoke(null, new object?[] { this, child })!;

                return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    /// <summary>
    ///     Undoes the "Registration" of a child with its parent.
    /// </summary>
    /// <param name="child">
    ///     The child to unregister
    /// </param>
    /// <remarks>
    ///     This method is an implementation detail and should not be called directly by consumers. In future versions, this may be changed to an internal method.
    /// </remarks>
    public virtual async Task UnregisterChildComponent(MapComponent child)
    {
        try
        {
            Assembly proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
            _proExtensions ??= proAssembly.GetType("dymaptic.GeoBlazor.Pro.ProExtensions");
            MethodInfo? method = _proExtensions?.GetMethod("UnregisterProChildComponent");

            if (method is not null)
            {
                await (Task)method.Invoke(null, new object?[] { this, child })!;

                return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    /// <summary>
    ///     Provides a way to externally call `StateHasChanged` on the component.
    /// </summary>
    public virtual void Refresh()
    {
        UpdateState();
    }

    /// <summary>
    ///     Toggles the visibility of the component.
    /// </summary>
    /// <param name="visible">
    ///     The new value to set for visibility of the component.
    /// </param>
    public async Task SetVisibility(bool visible)
    {
        await JsModule!.InvokeVoidAsync("setVisibility", CancellationTokenSource.Token, Id, visible);
        Visible = visible;
    }

    /// <summary>
    ///     The reference to the .NET object that represents the component.
    /// </summary>
    public DotNetObjectReference<MapComponent> DotNetComponentReference => DotNetObjectReference.Create(this);

    /// <summary>
    ///     The reference to the JavaScript object that represents the component.
    /// </summary>
    [JsonIgnore]
    protected IJSObjectReference? JsComponentReference { get; set; }
    
    /// <summary>
    ///     For internal use, registration from JavaScript.
    /// </summary>
    [JSInvokable]
    public void OnJsComponentCreated(IJSObjectReference jsComponentReference)
    {
        JsComponentReference = jsComponentReference;
    }
    
    /// <summary>
    ///     When a <see cref="MapView" /> is prepared to render, this will check to make sure that all properties with the
    ///     <see cref="RequiredPropertyAttribute" /> are provided.
    /// </summary>
    /// <exception cref="MissingRequiredChildElementException">
    ///     The consumer needs to provide the missing child component
    /// </exception>
    /// <exception cref="MissingRequiredOptionsChildElementException">
    ///     The consumer needs to provide ONE of the options of child components
    /// </exception>
    internal virtual void ValidateRequiredChildren()
    {
        Type thisType = GetType();

        IEnumerable<PropertyInfo> parameters = thisType
            .GetProperties()
            .Where(p =>
                Attribute.IsDefined(p, typeof(RequiredPropertyAttribute)));

        List<ComponentOption> options = new();

        foreach (PropertyInfo requiredParameter in parameters)
        {
            Type propType = requiredParameter.PropertyType;
            object? value = requiredParameter.GetValue(this);
            string propName = requiredParameter.Name;

            var attr =
                (RequiredPropertyAttribute)requiredParameter.GetCustomAttributes(typeof(RequiredPropertyAttribute),
                    true)[0];

            if (attr.OtherOptions is not null && attr.OtherOptions.Any())
            {
                ComponentOption? optionSet = options.FirstOrDefault(o =>
                    o.Options.Contains(propName));

                if (optionSet is null)
                {
                    optionSet = new ComponentOption();
                    optionSet.Options.Add(propName);

                    foreach (string other in attr.OtherOptions)
                    {
                        optionSet.Options.Add(other);
                    }

                    options.Add(optionSet);
                }

                if (value is not null)
                {
                    optionSet.Found = true;
                }
                continue;
            }
            
            if (value is null)
            {
                throw new MissingRequiredChildElementException(thisType.Name, propName);
            }

            // lists, arrays
            if ((propType.GetInterface(nameof(ICollection)) != null) && (((ICollection)value).Count == 0))
            {
                throw new MissingRequiredChildElementException(thisType.Name, propName);
            }
        }

        foreach (ComponentOption option in options)
        {
            if (!option.Found)
            {
                throw new MissingRequiredOptionsChildElementException(thisType.Name, option.Options);
            }
        }
    }

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (Parent is not null && !_registered)
        {
            await Parent.RegisterChildComponent(this);
            _registered = true;
        }
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        
        foreach (KeyValuePair<string, object?> kvp in ModifiedParameters)
        {
            try
            {
                GetType().GetProperty(kvp.Key)?.SetValue(this, kvp.Value);
            }
            catch
            {
                // user set a value in `SetProperty` that doesn't match a known property
                // don't log this
            }
        }
    }

    /// <inheritdoc />
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        IsRenderedBlazorComponent = true;
    }

    /// <summary>
    ///     Tells the <see cref="MapView" /> to completely re-render.
    /// </summary>
    /// <param name="forceRender">
    ///     Optional parameter, if set, will re-render even if other logic says it is not needed.
    /// </param>
    protected virtual async Task RenderView(bool forceRender = false)
    {
        if (Parent is not null)
        {
            await Parent.RenderView(forceRender);
        }
    }

    private readonly Dictionary<string, (Delegate Handler, IJSObjectReference JsObjRef)> _watchers = new();
    private readonly Dictionary<string, (Delegate Handler, IJSObjectReference JsObjRef)> _listeners = new();
    private readonly Dictionary<string, (Delegate Handler, IJSObjectReference JsObjRef)> _waiters = new();
    private Type? _proExtensions;

    /// <summary>
    ///     Properties that were modified in code, and should no longer be set via markup, but instead set to the value here.
    /// </summary>
    protected Dictionary<string, object?> ModifiedParameters = new();

    /// <summary>
    ///     Creates a cancellation token to control external calls
    /// </summary>
    protected readonly CancellationTokenSource CancellationTokenSource = new();

#region Events

    /// <summary>
    ///     Tracks any properties accessed in the <code>watchExpression</code> and calls the callback when any of them change.
    /// </summary>
    /// <param name="watchExpression">
    ///     Expression used to get the current value. All accessed properties will be tracked.
    /// </param>
    /// <param name="handler">
    ///     The function to call when there are changes.
    /// </param>
    /// <param name="targetName">
    ///     The name of the target you are referencing in the <code>watchExpression</code>. For example, if the expression is
    ///     "layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on
    ///     which this method was called.
    /// </param>
    /// <param name="once">
    ///     Whether to fire the callback only once.
    /// </param>
    /// <param name="initial">
    ///     Whether to fire the callback immediately after initialization, if the necessary conditions are met.
    /// </param>
    /// <typeparam name="T">
    ///     The type of return value to expect in the handler.
    /// </typeparam>
    /// <exception cref="UnMatchedTargetNameException">
    ///     This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.
    /// </exception>
    /// <remarks>
    ///     For adding watchers to types other than <see cref="MapView" /> and <see cref="SceneView" />, the default
    ///     <code>targetName</code> should not be relied upon. Make sure it matches the variable in your
    ///     <code>watchExpression</code>
    /// </remarks>
    public Task AddReactiveWatcher<T>(string watchExpression, Func<T, Task> handler, string? targetName = null,
        bool once = false, bool initial = false)
    {
        return AddReactiveWatcherImplementation(watchExpression, handler, targetName, once, initial);
    }

    /// <summary>
    ///     Tracks any properties accessed in the <code>watchExpression</code> and calls the callback when any of them change.
    /// </summary>
    /// <param name="watchExpression">
    ///     Expression used to get the current value. All accessed properties will be tracked.
    /// </param>
    /// <param name="handler">
    ///     The function to call when there are changes.
    /// </param>
    /// <param name="targetName">
    ///     The name of the target you are referencing in the <code>watchExpression</code>. For example, if the expression is
    ///     "layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on
    ///     which this method was called.
    /// </param>
    /// <param name="once">
    ///     Whether to fire the callback only once.
    /// </param>
    /// <param name="initial">
    ///     Whether to fire the callback immediately after initialization, if the necessary conditions are met.
    /// </param>
    /// <typeparam name="T">
    ///     The type of return value to expect in the handler.
    /// </typeparam>
    /// <exception cref="UnMatchedTargetNameException">
    ///     This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.
    /// </exception>
    /// <remarks>
    ///     For adding watchers to types other than <see cref="MapView" /> and <see cref="SceneView" />, the default
    ///     <code>targetName</code> should not be relied upon. Make sure it matches the variable in your
    ///     <code>watchExpression</code>
    /// </remarks>

    // ReSharper disable once UnusedMethodReturnValue.Global
    public Task AddReactiveWatcher<T>(string watchExpression, Action<T> handler, string? targetName = null,
        bool once = false, bool initial = false)
    {
        return AddReactiveWatcherImplementation(watchExpression, handler, targetName, once, initial);
    }

    /// <inheritdoc />
    protected override bool ShouldRender()
    {
        return AllowRender;
    }
    
    /// <summary>
    ///     Updates the state of the component, but only if it was added in normal Blazor Markup.
    /// </summary>
    protected void UpdateState(bool mainThread = true)
    {
        if (IsRenderedBlazorComponent)
        {
            InvokeAsync(StateHasChanged);
        }
    }

    /// <summary>
    ///     Whether to allow the component to render on the next cycle.
    /// </summary>
    public bool AllowRender = true;
    
    /// <summary>
    ///     Determines whether the component was added as a markup Blazor component or programmatically.
    /// </summary>
    protected bool IsRenderedBlazorComponent;
    private bool _registered;
    

    private async Task AddReactiveWatcherImplementation(string watchExpression, Delegate handler, string? targetName,
        bool once, bool initial)
    {
        string typeName = GetType().Name;
        targetName ??= typeName.Contains("View") ? "view" : typeName.ToLowerFirstChar();

        if (!watchExpression.Contains(targetName))
        {
            throw new UnMatchedTargetNameException(targetName, watchExpression);
        }

        IJSObjectReference? jsRef =
            await JsModule!.InvokeAsync<IJSObjectReference?>("addReactiveWatcher", Id,
                targetName, watchExpression, once, initial, DotNetObjectReference.Create(this));

        if (jsRef != null)
        {
            _watchers[watchExpression] = (handler, jsRef);
        }
    }

    /// <summary>
    ///     Removes the tracker on a particular expression.
    /// </summary>
    /// <param name="watchExpression">
    ///     The expression to stop tracking.
    /// </param>
    public async Task RemoveReactiveWatcher(string watchExpression)
    {
        if (_watchers.ContainsKey(watchExpression))
        {
            IJSObjectReference jsRef = _watchers[watchExpression].JsObjRef;
            await jsRef.InvokeVoidAsync("remove");
            _watchers.Remove(watchExpression);
        }
    }

#pragma warning disable CS1574, CS0419
    /// <summary>
    ///     JS-Invokable method that is triggered by the reactiveUtils watchers. This method will dynamically trigger handlers
    ///     passed to <see cref="AddReactiveWatcher" />
    /// </summary>
    /// <param name="watchExpression">
    ///     The tracked expression that was triggered.
    /// </param>
    /// <param name="value">
    ///     The return value of the watcher callback.
    /// </param>
#pragma warning restore CS1574, CS0419
    [JSInvokable]
    public void OnReactiveWatcherUpdate(string watchExpression, JsonElement? value)
    {
        Delegate handler = _watchers[watchExpression].Handler;
        Type returnType = handler.Method.GetParameters()[0].ParameterType;
        object? typedValue = null;

        if (value.HasValue)
        {
            var stringValue = value.Value.ToString();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            typedValue = value.Value.ValueKind switch
            {
                JsonValueKind.Object => value.Value.Deserialize(returnType, options),
                JsonValueKind.Array => value.Value.Deserialize(returnType, options),
                JsonValueKind.False => false,
                JsonValueKind.True => true,
                JsonValueKind.Number => Convert.ChangeType(stringValue, returnType),
                JsonValueKind.String => stringValue,
                _ => typedValue
            };
        }

        handler.DynamicInvoke(typedValue);
    }

    /// <summary>
    ///     Tracks any properties accessed in the <code>listenExpression</code> and calls the callback when any of them change.
    /// </summary>
    /// <param name="eventName">
    ///     The name of the event to add a listener for.
    /// </param>
    /// <param name="handler">
    ///     The function to call when the event triggers.
    /// </param>
    /// <param name="once">
    ///     Whether to fire the callback only once. Defaults to false.
    /// </param>
    /// <typeparam name="T">
    ///     The type of return value to expect in the handler.
    /// </typeparam>
    public async Task AddReactiveListener<T>(string eventName, Func<T, Task> handler, bool once = false)
    {
        IJSObjectReference? jsRef =
            await JsModule!.InvokeAsync<IJSObjectReference?>("addReactiveListener", Id, eventName, once,
                DotNetObjectReference.Create(this));

        if (jsRef != null)
        {
            _listeners[eventName] = (handler, jsRef);
        }
    }

    /// <summary>
    ///     Tracks any properties accessed in the <code>listenExpression</code> and calls the callback when any of them change.
    /// </summary>
    /// <param name="eventName">
    ///     The name of the event to add a listener for.
    /// </param>
    /// <param name="handler">
    ///     The function to call when there are changes.
    /// </param>
    /// <param name="once">
    ///     Whether to fire the callback only once. Defaults to false.
    /// </param>
    /// <typeparam name="T">
    ///     The type of return value to expect in the handler.
    /// </typeparam>
    public async Task AddReactiveListener<T>(string eventName, Action<T> handler, bool once = false)
    {
        IJSObjectReference? jsRef =
            await JsModule!.InvokeAsync<IJSObjectReference?>("addReactiveListener", Id, eventName, once,
                DotNetObjectReference.Create(this));

        if (jsRef != null)
        {
            _listeners[eventName] = (handler, jsRef);
        }
    }

    /// <summary>
    ///     Removes the tracker on a particular expression.
    /// </summary>
    /// <param name="eventName">
    ///     The expression to stop tracking.
    /// </param>
    public async Task RemoveReactiveListener(string eventName)
    {
        if (_listeners.ContainsKey(eventName))
        {
            IJSObjectReference jsRef = _listeners[eventName].JsObjRef;
            await jsRef.InvokeVoidAsync("remove");
            _listeners.Remove(eventName);
        }
    }

#pragma warning disable CS1574, CS0419
    /// <summary>
    ///     JS-Invokable method that is triggered by the reactiveUtils 'on' listeners. This method will dynamically trigger
    ///     handlers passed to <see cref="AddReactiveListener" />
    /// </summary>
    /// <param name="eventName">
    ///     The tracked event that was triggered.
    /// </param>
    /// <param name="value">
    ///     The return value of the watcher callback.
    /// </param>
#pragma warning restore CS1574, CS0419
    [JSInvokable]
    public void OnReactiveListenerTriggered(string eventName, JsonElement? value)
    {
        Delegate handler = _listeners[eventName].Handler;
        Type returnType = handler.Method.GetParameters()[0].ParameterType;
        object? typedValue = null;

        if (value.HasValue)
        {
            var stringValue = value.Value.ToString();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            typedValue = value.Value.ValueKind switch
            {
                JsonValueKind.Object => value.Value.Deserialize(returnType, options),
                JsonValueKind.Array => value.Value.Deserialize(returnType, options),
                JsonValueKind.False => false,
                JsonValueKind.True => true,
                JsonValueKind.Number => Convert.ChangeType(stringValue, returnType),
                JsonValueKind.String => stringValue,
                _ => typedValue
            };
        }

        handler.DynamicInvoke(typedValue);
    }

    /// <summary>
    ///     Tracks a value in the <code>waitExpression</code> and calls the callback when it becomes
    ///     <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Glossary/Truthy">truthy</a>.
    /// </summary>
    /// <param name="waitExpression">
    ///     Expression used to get the current value. All accessed properties will be tracked.
    /// </param>
    /// <param name="handler">
    ///     The function to call when the value is truthy.
    /// </param>
    /// <param name="targetName">
    ///     The name of the target you are referencing in the <code>waitExpression</code>. For example, if the expression is
    ///     "layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on
    ///     which this method was called.
    /// </param>
    /// <param name="once">
    ///     Whether to fire the callback only once.
    /// </param>
    /// <param name="initial">
    ///     Whether to fire the callback immediately after initialization, if the necessary conditions are met.
    /// </param>
    /// <exception cref="UnMatchedTargetNameException">
    ///     This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.
    /// </exception>
    /// <remarks>
    ///     For adding waiters to types other than <see cref="MapView" /> and <see cref="SceneView" />, the default
    ///     <code>targetName</code> should not be relied upon. Make sure it matches the variable in your
    ///     <code>waitExpression</code>
    /// </remarks>
    public Task AddReactiveWaiter(string waitExpression, Func<Task> handler, string? targetName = null,
        bool once = false, bool initial = false)
    {
        return AddReactiveWaiterImplementation(waitExpression, handler, targetName, once, initial);
    }

    /// <summary>
    ///     Tracks a value in the <code>waitExpression</code> and calls the callback when it becomes
    ///     <a target="_blank" href="https://developer.mozilla.org/en-US/docs/Glossary/Truthy">truthy</a>.
    /// </summary>
    /// <param name="waitExpression">
    ///     Expression used to get the current value. All accessed properties will be tracked.
    /// </param>
    /// <param name="handler">
    ///     The function to call when the value is truthy.
    /// </param>
    /// <param name="targetName">
    ///     The name of the target you are referencing in the <code>waitExpression</code>. For example, if the expression is
    ///     "layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on
    ///     which this method was called.
    /// </param>
    /// <param name="once">
    ///     Whether to fire the callback only once.
    /// </param>
    /// <param name="initial">
    ///     Whether to fire the callback immediately after initialization, if the necessary conditions are met.
    /// </param>
    /// <exception cref="UnMatchedTargetNameException">
    ///     This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.
    /// </exception>
    /// <remarks>
    ///     For adding waiters to types other than <see cref="MapView" /> and <see cref="SceneView" />, the default
    ///     <code>targetName</code> should not be relied upon. Make sure it matches the variable in your
    ///     <code>waitExpression</code>
    /// </remarks>

    // ReSharper disable once UnusedMethodReturnValue.Global
    public Task AddReactiveWaiter(string waitExpression, Action handler, string? targetName = null,
        bool once = false, bool initial = false)
    {
        return AddReactiveWaiterImplementation(waitExpression, handler, targetName, once, initial);
    }

    private async Task AddReactiveWaiterImplementation(string waitExpression, Delegate handler, string? targetName,
        bool once, bool initial)
    {
        string typeName = GetType().Name;
        targetName ??= typeName.Contains("View") ? "view" : typeName.ToLowerFirstChar();

        if (!waitExpression.Contains(targetName))
        {
            throw new UnMatchedTargetNameException(targetName, waitExpression);
        }

        IJSObjectReference? jsRef =
            await JsModule!.InvokeAsync<IJSObjectReference?>("addReactiveWaiter", Id,
                targetName, waitExpression, once, initial, DotNetObjectReference.Create(this));

        if (jsRef != null)
        {
            _waiters[waitExpression] = (handler, jsRef);
        }
    }

    /// <summary>
    ///     Removes the tracker on a particular expression.
    /// </summary>
    /// <param name="waitExpression">
    ///     The expression to stop tracking.
    /// </param>
    public async Task RemoveReactiveWaiter(string waitExpression)
    {
        if (_waiters.ContainsKey(waitExpression))
        {
            IJSObjectReference jsRef = _waiters[waitExpression].JsObjRef;
            await jsRef.InvokeVoidAsync("remove");
            _waiters.Remove(waitExpression);
        }
    }

#pragma warning disable CS1574, CS0419
    /// <summary>
    ///     JS-Invokable method that is triggered by the reactiveUtils waiters. This method will dynamically trigger handlers
    ///     passed to <see cref="AddReactiveWaiter" />
    /// </summary>
    /// <param name="waitExpression">
    ///     The tracked expression that was triggered.
    /// </param>
#pragma warning restore CS1574, CS0419
    [JSInvokable]
    public void OnReactiveWaiterTrue(string waitExpression)
    {
        Delegate handler = _waiters[waitExpression].Handler;
        handler.DynamicInvoke();
    }

    /// <summary>
    ///     Tracks any properties being evaluated by the getValue function. When getValue changes, it returns a Task containing
    ///     the value. This method only tracks a single change.
    /// </summary>
    /// <param name="watchExpression">
    ///     The expression to be tracked.
    /// </param>
    /// <param name="targetName">
    ///     The name of the target you are referencing in the <code>waitExpression</code>. For example, if the expression is
    ///     "layer?.refresh", then the targetName should be "layer". The type of the target should also match the class on
    ///     which this method was called.
    /// </param>
    /// <param name="token">
    ///     Optional Cancellation Token to abort a listener.
    /// </param>
    /// <typeparam name="T">
    ///     The expected return type.
    /// </typeparam>
    /// <returns>
    ///     Returns the value from the evaluated property when it changes.
    /// </returns>
    /// <exception cref="UnMatchedTargetNameException">
    ///     This exception is thrown when a watchExpression's target object name doesn't match the targetName parameter.
    /// </exception>
    public async Task<T> AwaitReactiveSingleWatchUpdate<T>(string watchExpression, string? targetName = null,
        CancellationToken token = new())
    {
        string typeName = GetType().Name;
        targetName ??= typeName.Contains("View") ? "view" : typeName.ToLowerFirstChar();

        if (!watchExpression.Contains(targetName))
        {
            throw new UnMatchedTargetNameException(targetName, watchExpression);
        }

        return await JsModule!.InvokeAsync<T>("awaitReactiveSingleWatchUpdate", token, Id, targetName,
            watchExpression);
    }

#endregion
}

internal class MapComponentConverter : JsonConverter<MapComponent>
{
    public override MapComponent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeToConvert, options) as MapComponent;
    }

    public override void Write(Utf8JsonWriter writer, MapComponent value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}

internal record MapComponentSerializationRecord;