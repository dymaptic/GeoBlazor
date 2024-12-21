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
    
    [Inject]
    [JsonIgnore]
    public JsModuleManager JsModuleManager { get; set; } = default!;

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
    [Obsolete("Use the CoreJsModule property instead.")]
    [JsonIgnore]
    public IJSObjectReference? JsModule => CoreJsModule;

    /// <summary>
    ///     The reference to arcGisJsInterop.ts from .NET
    /// </summary>
    [JsonIgnore]
    public IJSObjectReference? CoreJsModule
    {
        get
        {
            if (_coreJsModule is null && Parent is not null)
            {
                _coreJsModule = Parent.CoreJsModule;
            }

            return _coreJsModule;
        }
        internal set => _coreJsModule = value;
    }

    /// <summary>
    ///     Optional JsModule for GeoBlazor Pro
    /// </summary>
    [JsonIgnore]
    public IJSObjectReference? ProJsModule
    {
        get
        {
            if (_proJsModule is null && Parent is not null)
            {
                _proJsModule = Parent.ProJsModule;
            }
            
            return _proJsModule;
        }
        internal set => _proJsModule = value;
    }
    
    /// <summary>
    ///     Handles conversion from .NET CancellationToken to JavaScript AbortController
    /// </summary>
    internal AbortManager? AbortManager { get; set; }

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
    ///     Whether the component has been disposed.
    /// </summary>
    [JsonIgnore]
    public bool IsDisposed { get; set; }
    
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
            if (await Parent.UnregisterGeneratedChildComponent(this))
            {
                _registered = false;
            }
            else
            {
                await Parent.UnregisterChildComponent(this);
                _registered = false;
            }
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

        if (CoreJsModule is not null)
        {
            try
            {
                await CoreJsModule.InvokeVoidAsync("disposeMapComponent", Id, View?.Id);
            }
            catch (JSDisconnectedException)
            {
                // it's fine
            }
        }
        
        if (JsComponentReference is not null)
        {
            await JsComponentReference.DisposeAsync();
        }

        CancellationTokenSource.Cancel();
        IsDisposed = true;
    }

    /// <summary>
    ///     Sets any property to a new value after initial render. Supports all basic types (strings, numbers, booleans, dictionaries) and properties.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to set.
    /// </param>
    /// <param name="value">
    ///     The new value.
    /// </param>
    /// <param name="updateInMemory">
    ///     Whether to update the in-memory value of the property as well as the ArcGIS JavaScript value. Default true.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the value to set.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the SetProperty method.
    /// </exception>
    public virtual async Task SetProperty<T>(string propertyName, T? value)
    {
        try
        {
            Props ??= GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo? prop = Props.FirstOrDefault(p => p.Name == propertyName);

            if (prop is null)
            {
                throw new NotSupportedException($"The component {GetType().Name} does not have a property named {
                    propertyName}.");
            }

            prop.SetValue(this, value);
            ModifiedParameters[propertyName] = value;

            if (CoreJsModule is null) return;

            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
                CancellationTokenSource.Token, Id);

            if (JsComponentReference is null)
            {
                throw new NotSupportedException($"The component {GetType().Name
                } does not currently support the SetProperty method. Please contact dymaptic for support.");
            }

            if (value is MapComponent component)
            {
                component.Parent = this;
                component.View = View;

                if (component.JsComponentReference is null)
                {
                    // new MapComponent, needs to be built and registered in JS
                    try
                    {
                        // this also calls back to OnJsComponentCreated
                        IJSObjectReference jsObjectReference = await CoreJsModule.InvokeAsync<IJSObjectReference>(
                            $"buildJs{prop.PropertyType.Name}", CancellationTokenSource.Token, 
                                value, View?.Id);
                        component.JsComponentReference ??= jsObjectReference;

                        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                            JsComponentReference, propertyName.ToLowerFirstChar(), jsObjectReference);

                        return;
                    }
                    catch
                    {
                        // try just passing the value directly below
                    }
                }
                else
                {
                    // this component has already been registered, but we'll call setProperty to make sure
                    // it is attached to the parent
                    await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
                        JsComponentReference,
                        propertyName.ToLowerFirstChar(), component.JsComponentReference);

                    return;
                }
            }

            await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference,
                propertyName.ToLowerFirstChar(), value);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of any property, based on the property name. You must also define the type of the property in the Generic type.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to get.
    /// </param>
    /// <param name="updateInMemory">
    ///     Whether to update the in-memory value of the property when retrieving from JavaScript. Default true.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the value to get.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the GetProperty method.
    /// </exception>
    public virtual async Task<T?> GetProperty<T>(string propertyName)
    {
        Props ??= GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        PropertyInfo prop = Props.First(p => p.Name == propertyName);
        T? currentValue = (T?)prop.GetValue(this);
        
        if (CoreJsModule is null)
        {
            // we aren't hooked to JS, so return the current value in memory
            return currentValue;
        }
                 
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            // we aren't hooked to JS, so return the current value in memory
            return currentValue;
        }
        
        bool isMapComponent = prop.PropertyType.IsAssignableTo(typeof(MapComponent));

        try
        {
            if (isMapComponent)
            {
                if (currentValue is MapComponent { JsComponentReference: not null })
                {
                    // this component has already been registered
                    return currentValue;
                }

                // get the JS object reference
                IJSObjectReference? refResult = await CoreJsModule!.InvokeAsync<IJSObjectReference?>("getProperty",
                    CancellationTokenSource.Token, JsComponentReference, propertyName.ToLowerFirstChar());

                if (refResult is null)
                {
                    return default;
                }

                Type instanceType = typeof(T);
                T? instance = default;
                if (instanceType.IsAbstract)
                {
                    // try to read the "type" from the JS object
                    string? typeName = await CoreJsModule.InvokeAsync<string?>("getProperty",
                        CancellationTokenSource.Token, refResult, "type");

                    List<Type> childTypes = Assembly
                        .GetAssembly(instanceType)!
                        .GetTypes()
                        .Where(t => t.IsAssignableTo(instanceType))
                        .ToList();
                    
                    // try instantiating each one to read the "type" property
                    if (typeName is null)
                    {
                        instance = (T)Activator.CreateInstance(childTypes.First())!;
                    }
                    else
                    {
                        foreach (Type childType in childTypes)
                        {
                            instance = (T)Activator.CreateInstance(childType)!;
                            string subType = (string)childType.GetProperty("Type")!.GetValue(instance)!;

                            if (subType == typeName)
                            {
                                break;
                            }
                        }
                    }
                }

                MapComponent component = (instance as MapComponent)!;
                prop.SetValue(this, instance);
                component.Parent = this;
                component.View = View;

                // register this type in JS
                await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorObject",
                    CancellationTokenSource.Token, component.JsComponentReference, component.Id);
                
                // call to set other values
                await component.OnJsComponentCreated(refResult);
                
                ModifiedParameters[propertyName] = component;

                return instance;
            }

            // non MapComponent, return value from JS
            T? result = await CoreJsModule!.InvokeAsync<T?>("getProperty",
                CancellationTokenSource.Token, JsComponentReference, propertyName.ToLowerFirstChar());
            prop.SetValue(this, result);
            ModifiedParameters[propertyName] = result;

            return result;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error calling GetProperty for property {propertyName} on component {GetType().Name}: {ex}");
            return currentValue;
        }
    }
    
    /// <summary>
    ///     Asynchronously add a value to a property that is a collection.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to add to.
    /// </param>
    /// <param name="value">
    ///     The value to add to the property.
    /// </param>
    /// <param name="updateInMemory">
    ///     Whether to update the in-memory collection of the property when adding to ArcGIS JavaScript. Default true.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the value to add.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the AddToProperty method.
    /// </exception>
    public virtual async Task AddToProperty<T>(string propertyName, T value, bool updateInMemory = true)
    {
        if (updateInMemory)
        {
            Props ??= GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo? prop = Props.FirstOrDefault(p => p.CanWrite && 
                (p.Name == propertyName || p.Name == $"_{propertyName.ToLowerFirstChar()}"));
            object? currentValue = prop?.GetValue(this);
            if (currentValue is ICollection collection)
            {
                MethodInfo? addMethod = collection.GetType().GetMethod("Add");
                addMethod?.Invoke(collection, [value]);
            }
            ModifiedParameters[propertyName] = prop!.GetValue(this);
        }
        
        if (CoreJsModule is null) return;
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            throw new NotSupportedException(
                $"The component {GetType().Name} does not currently support the AddToProperty method. Please contact dymaptic for support.");
        }
        await CoreJsModule.InvokeVoidAsync("addToProperty", CancellationTokenSource.Token, JsComponentReference, 
            propertyName.ToLowerFirstChar(), value);
    }
    
    /// <summary>
    ///     Asynchronously adds a set of values to a property that is a collection.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to add to.
    /// </param>
    /// <param name="values">
    ///     The values to add to the property.
    /// </param>
    /// <param name="updateInMemory">
    ///     Whether to update the in-memory collection of the property when adding to ArcGIS JavaScript. Default true.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the values to add.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the AddToProperty method.
    /// </exception>
    public virtual async Task AddToProperty<T>(string propertyName, IReadOnlyList<T> values, bool updateInMemory = true)
    {
        if (updateInMemory)
        {
            Props ??= GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo? prop = Props.FirstOrDefault(p => p.CanWrite && 
                (p.Name == propertyName || p.Name == $"_{propertyName.ToLowerFirstChar()}"));
            object? currentValue = prop?.GetValue(this);
            if (currentValue is ICollection collection)
            {
                MethodInfo? addMethod = collection.GetType().GetMethod("Add");
                foreach (T value in values)
                {
                    addMethod?.Invoke(collection, [value]);
                }
                ModifiedParameters[propertyName] = prop!.GetValue(this);
            }
        }
        
        if (CoreJsModule is null) return;
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            throw new NotSupportedException(
                $"The component {GetType().Name} does not currently support the AddToProperty method. Please contact dymaptic for support.");
        }
        await CoreJsModule.InvokeVoidAsync("addToProperty", CancellationTokenSource.Token, JsComponentReference, 
            propertyName.ToLowerFirstChar(), values);
    }

    /// <summary>
    ///     Asynchronously remove a value from a property that is a collection.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to remove from.
    /// </param>
    /// <param name="value">
    ///     The value to remove from the property.
    /// </param>
    /// <param name="updateInMemory">
    ///     Whether to update the in-memory collection of the property when removing from ArcGIS JavaScript. Default true.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the value to remove.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the RemoveFromProperty method.
    /// </exception>
    public virtual async Task RemoveFromProperty<T>(string propertyName, T value, bool updateInMemory = true)
    {
        if (updateInMemory)
        {
            Props ??= GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo? prop = Props.FirstOrDefault(p => p.CanWrite && 
                (p.Name == propertyName || p.Name == $"_{propertyName.ToLowerFirstChar()}"));
            object? currentValue = prop?.GetValue(this);
            if (currentValue is ICollection collection)
            {
                MethodInfo? removeMethod = collection.GetType().GetMethod("Remove");
                removeMethod?.Invoke(collection, [value]);
                ModifiedParameters[propertyName] = prop!.GetValue(this);
            }
        }
        if (CoreJsModule is null) return;
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            throw new NotSupportedException(
                $"The component {GetType().Name} does not currently support the AddToProperty method. Please contact dymaptic for support.");
        }
        await CoreJsModule.InvokeVoidAsync("removeFromProperty", CancellationTokenSource.Token, JsComponentReference, 
            propertyName.ToLowerFirstChar(), value);
    }
    
    /// <summary>
    ///     Asynchronously remove a set of values from a property that is a collection.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to remove from.
    /// </param>
    /// <param name="values">
    ///     The values to remove from the property.
    /// </param>
    /// <param name="updateInMemory">
    ///     Whether to update the in-memory collection of the property when removing from ArcGIS JavaScript. Default true.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the values to remove.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the RemoveFromProperty method.
    /// </exception>
    public virtual async Task RemoveFromProperty<T>(string propertyName, IReadOnlyList<T> values, bool updateInMemory = true)
    {
        if (updateInMemory)
        {
            Props ??= GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo? prop = Props.FirstOrDefault(p => p.CanWrite && 
                (p.Name == propertyName || p.Name == $"_{propertyName.ToLowerFirstChar()}"));
            object? currentValue = prop?.GetValue(this);
            if (currentValue is ICollection collection)
            {
                MethodInfo? removeMethod = collection.GetType().GetMethod("Remove");
                foreach (T value in values)
                {
                    removeMethod?.Invoke(collection, [value]);
                }
                ModifiedParameters[propertyName] = prop!.GetValue(this);
            }
        }
        if (CoreJsModule is null) return;
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            throw new NotSupportedException(
                $"The component {GetType().Name} does not currently support the AddToProperty method. Please contact dymaptic for support.");
        }
        await CoreJsModule.InvokeVoidAsync("removeFromProperty", CancellationTokenSource.Token, JsComponentReference, 
            propertyName.ToLowerFirstChar(), values);
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
        if (!ProNotFound)
        {
            try
            {
                // register pro components that can be children of core components
                Assembly proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
                _proExtensions ??= proAssembly.GetType("dymaptic.GeoBlazor.Pro.ProExtensions");
                MethodInfo? method = _proExtensions?.GetMethod("RegisterProChildComponent");

                if (method is not null)
                {
                    await (Task)method.Invoke(null, [this, child])!;

                    return;
                }
            }
            catch
            {
                ProNotFound = true;
            }
        }

        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    /// <summary>
    ///     Register a child component that was created with a source generator.
    /// </summary>
    protected virtual ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        return ValueTask.FromResult(false);
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
        if (!ProNotFound)
        {
            try
            {
                // unregister pro components that can be children of core components
                Assembly proAssembly = Assembly.Load("dymaptic.GeoBlazor.Pro");
                _proExtensions ??= proAssembly.GetType("dymaptic.GeoBlazor.Pro.ProExtensions");
                MethodInfo? method = _proExtensions?.GetMethod("UnregisterProChildComponent");

                if (method is not null)
                {
                    await (Task)method.Invoke(null, [this, child])!;

                    return;
                }
            }
            catch
            {
                ProNotFound = true;
            }
        }

        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    /// <summary>
    ///     Unregister a child component that was created with a source generator.
    /// </summary>
    protected virtual ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        return ValueTask.FromResult(false);
    }

    /// <summary>
    ///     Provides a way to externally call `StateHasChanged` on the component.
    /// </summary>
    public virtual ValueTask Refresh()
    {
        UpdateState();
        return ValueTask.CompletedTask;
    }

    /// <summary>
    ///     Toggles the visibility of the component.
    /// </summary>
    /// <param name="visible">
    ///     The new value to set for visibility of the component.
    /// </param>
    public async Task SetVisibility(bool visible)
    {
        await CoreJsModule!.InvokeVoidAsync("setVisibility", CancellationTokenSource.Token, Id, visible);
        ModifiedParameters[nameof(Visible)] = visible;
        Visible = visible;
    }
    
    /// <summary>
    ///     The reference to the .NET object that represents the component.
    /// </summary>
    [JsonConverter(typeof(DotNetObjectReferenceJsonConverter))]
    public DotNetObjectReference<MapComponent> DotNetComponentReference => DotNetObjectReference.Create(this);

    /// <summary>
    ///     The reference to the JavaScript object that represents the component.
    /// </summary>
    [JsonIgnore]
    internal IJSObjectReference? JsComponentReference { get; set; }
    
    /// <summary>
    ///     For internal use, registration from JavaScript.
    /// </summary>
    [JSInvokable]
    public async Task OnJsComponentCreated(IJSObjectReference jsComponentReference)
    {
        JsComponentReference = jsComponentReference;
        PropertyInfo[] arcGisProps = GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(p => p.SetMethod is not null 
                && p.GetCustomAttribute<ArcGISPropertyAttribute>() is not null)
            .ToArray();

        foreach (PropertyInfo prop in arcGisProps)
        {
            try
            {
                // call GetProperty with reflection
                MethodInfo method = GetType().GetMethod("GetProperty")!.MakeGenericMethod(prop.PropertyType);
                Task methodTask = (Task)method.Invoke(this, [prop.Name])!;
                await methodTask;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
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
        if (IsValidated) return;
        
        Props ??= GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        
        IEnumerable<PropertyInfo> requiredParameters = Props.Where(p =>
                Attribute.IsDefined(p, typeof(RequiredPropertyAttribute)));

        List<ComponentOption> options = [];

        foreach (PropertyInfo requiredParameter in requiredParameters)
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
                throw new MissingRequiredChildElementException(GetType().Name, propName);
            }

            // lists, arrays
            if (propType.GetInterface(nameof(ICollection)) != null && ((ICollection)value).Count == 0)
            {
                throw new MissingRequiredChildElementException(GetType().Name, propName);
            }
        }

        foreach (ComponentOption option in options)
        {
            if (!option.Found)
            {
                throw new MissingRequiredOptionsChildElementException(GetType().Name, option.Options);
            }
        }
        
        IsValidated = true;
    }
    
    /// <summary>
    ///     Validates source-generated child components.
    /// </summary>
    internal virtual void ValidateRequiredGeneratedChildren()
    {
        
    }

    /// <summary>
    ///     Reflection-based properties of the component.
    /// </summary>
    protected PropertyInfo[]? Props;

    protected bool IsValidated;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        
        if (Parent is not null && !_registered)
        {
            if (await Parent.RegisterGeneratedChildComponent(this))
            {
                _registered = true;
                return;
            }
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
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            ProJsModule ??= await JsModuleManager.GetArcGisJsPro(JsRuntime, default);
            CoreJsModule ??= await JsModuleManager.GetArcGisJsCore(JsRuntime, ProJsModule, default);
            AbortManager ??= new AbortManager(CoreJsModule);
        }
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
    private static Type? _proExtensions;

    /// <summary>
    ///     Properties that were modified in code, and should no longer be set via markup, but instead set to the value here.
    /// </summary>
    protected internal Dictionary<string, object?> ModifiedParameters = new();

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
    private IJSObjectReference? _coreJsModule;
    private IJSObjectReference? _proJsModule;

    /// <summary>
    ///     The application is running with just GeoBlazor Core, not Pro
    /// </summary>
    protected static bool ProNotFound;


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
            await CoreJsModule!.InvokeAsync<IJSObjectReference?>("addReactiveWatcher", Id,
                targetName, watchExpression, once, initial, DotNetComponentReference);

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
            await CoreJsModule!.InvokeAsync<IJSObjectReference?>("addReactiveListener", Id, eventName, once,
                DotNetComponentReference);

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
            await CoreJsModule!.InvokeAsync<IJSObjectReference?>("addReactiveListener", Id, eventName, once,
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
            await CoreJsModule!.InvokeAsync<IJSObjectReference?>("addReactiveWaiter", Id,
                targetName, waitExpression, once, initial, DotNetComponentReference);

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

        return await CoreJsModule!.InvokeAsync<T>("awaitReactiveSingleWatchUpdate", token, Id, targetName,
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
        _options ??= new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
        
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), _options));
    }

    private JsonSerializerOptions? _options;
}

/// <summary>
///     Custom converter to ensure that end users can serialize things like Graphics without getting hit by a loop with the `DotNetComponentReference` property that causes a Stack Overflow.
/// </summary>
internal class DotNetObjectReferenceJsonConverter : JsonConverter<DotNetObjectReference<MapComponent>>
{
    public override DotNetObjectReference<MapComponent>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeToConvert, options) as DotNetObjectReference<MapComponent>;
    }

    public override void Write(Utf8JsonWriter writer, DotNetObjectReference<MapComponent> value, JsonSerializerOptions options)
    {
        // Using for loop for performance since this is hit a lot. Looking at the JsRuntime source, it would be possible right
        // now to know that the _first_ converter can handle this type, but that could change in the future.
        for (int i = 0; i < options.Converters.Count; i++)
        {
            if (options.Converters[i].CanConvert(typeof(DotNetObjectReference<MapComponent>)))
            {
                JsonSerializer.Serialize(writer, value, options);
                return;
            }
        }
        
        writer.WriteNullValue();
    }
}

internal record MapComponentSerializationRecord;