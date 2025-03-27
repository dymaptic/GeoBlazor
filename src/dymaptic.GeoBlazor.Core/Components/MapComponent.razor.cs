namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     The abstract base Razor Component class that all GeoBlazor components derive from.
/// </summary>
[JsonConverter(typeof(MapComponentConverter))]
public abstract partial class MapComponent : ComponentBase, IAsyncDisposable, IMapComponent
{
    /// <summary>
    ///     Represents an instance of a JavaScript runtime to which calls may be dispatched.
    /// </summary>
    [Inject]
    [JsonIgnore]
    public IJSRuntime? JsRuntime { get; set; }
    
    /// <summary>
    ///     Manages references to JavaScript modules.
    /// </summary>
    [Inject]
    [JsonIgnore]
    public JsModuleManager? JsModuleManager { get; set; }

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
    ///     The reference to the entry point arcGisJsInterop.js from .NET
    /// </summary>
    [JsonIgnore]
    public IJSObjectReference? CoreJsModule
    {
        get
        {
            _coreJsModule ??= Parent?.CoreJsModule;
            return _coreJsModule;
        }
        set => _coreJsModule = value;
    }

    /// <summary>
    ///     Optional JsModule for GeoBlazor Pro
    /// </summary>
    [JsonIgnore]
    public IJSObjectReference? ProJsModule
    {
        get
        {
            _proJsModule ??= Parent?.ProJsModule;
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
    ///     The ID of the parent <see cref="MapView" /> of the current component.
    /// </summary>
    public Guid? ViewId
    {
        get => _viewId ??= View?.Id;
        set => _viewId = value;
    }

    /// <summary>
    ///     The relevant Layer for the MapComponent. Not always applicable to every component type.
    /// </summary>
    [JsonIgnore]
    [Parameter]
    public virtual Layer? Layer { get; set; }
    
    /// <summary>
    ///     The Id of the relevant Layer for the MapComponent. Not always applicable to every component type.
    /// </summary>
    [Parameter]
    public Guid? LayerId { get; set; }

    /// <summary>
    ///     Indicates the visibility of the component. Default value: true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Visible { get; set; }

    /// <summary>
    ///     A unique identifier, used to track components across .NET and JavaScript.
    /// </summary>
    [JsonConverter(typeof(DefaultGuidConverter))]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    ///     Whether the component has been disposed.
    /// </summary>
    [JsonIgnore]
    public bool IsDisposed { get; private set; }

    /// <summary>
    ///     Implements the `IAsyncDisposable` pattern.
    /// </summary>
    public virtual async ValueTask DisposeAsync()
    {
        try
        {
            await CancellationTokenSource.CancelAsync();
            IsDisposed = true;

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
                await CoreJsModule.InvokeVoidAsync("disposeMapComponent", Id, View?.Id);
            }

            if (JsComponentReference is not null)
            {
                await JsComponentReference.DisposeAsync();
            }
        }
        catch (TaskCanceledException)
        {
            // user cancelled
        }
        catch (JSDisconnectedException)
        {
            // lost connection (page navigation)
        }
        catch (JSException)
        {
            // instance already destroyed
        }
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
    /// <typeparam name="T">
    ///     The type of the value to set.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the SetProperty method.
    /// </exception>
    public virtual async Task SetProperty<T>(string propertyName, T? value)
    {
        if (GetType().GetMethod($"Set{propertyName}") is { } typedMethod)
        {
            Task methodTask = (Task)typedMethod.Invoke(this, [value])!;

            await methodTask.ConfigureAwait(false);

            return;
        }
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
    /// <typeparam name="T">
    ///     The type of the value to get.
    /// </typeparam>
    /// <exception cref="NotSupportedException">
    ///     Throws if the component does not support the GetProperty method.
    /// </exception>
    public virtual async Task<T?> GetProperty<T>(string propertyName)
    {
        Type componentType = GetType();

        if (componentType.GetMethod($"Get{propertyName}") is { } typedMethod)
        {
            Task methodTask = (Task)typedMethod.Invoke(this, [])!;

            await methodTask.ConfigureAwait(false);
            return methodTask.GetType().GetProperty("Result")!.GetValue(methodTask) is T result ? result : default;
        }
        
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
        Type instanceType = typeof(T);
        T? instance = default;

        try
        {
            if (isMapComponent)
            {
                if (currentValue is MapComponent { JsComponentReference: not null })
                {
                    // this component has already been registered
                    return currentValue;
                }
                
                IJSObjectReference? refResult;

                try
                {
                    // get the JS object reference to compare exact types for instantiation and set child properties
                    // we have to wrap the JsObjectReference because a null will throw an error
                    // https://github.com/dotnet/aspnetcore/issues/52070
                    refResult = (await CoreJsModule!.InvokeAsync<JsObjectRefWrapper?>("getObjectRefForProperty",
                        CancellationTokenSource.Token, JsComponentReference, propertyName.ToLowerFirstChar()))?.Value;
                }
                catch
                {
                    refResult = null;
                }

                try
                {
                    // try using built in deserialization
                    instance = await CoreJsModule!.InvokeAsync<T?>("getProperty",
                        CancellationTokenSource.Token, JsComponentReference, propertyName.ToLowerFirstChar());
                }
                catch
                {
                    // Try to deserialize the object with the JS method. This might fail if we don't have the
                    // all deserialization edge cases handled.
                    try
                    {
                        instance = await CoreJsModule.InvokeAsync<T?>("createGeoBlazorObject",
                            CancellationTokenSource.Token, refResult);
                    }
                    catch
                    {
                        // continue, we'll try to instantiate the object below
                    }
                    
                    if (instanceType.IsAbstract)
                    {
                        if (refResult is null)
                        {
                            return default;
                        }

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
                    else
                    {
                        instance = (T)Activator.CreateInstance(instanceType)!;
                    }
                }

                if (instance is null)
                {
                    return default;
                }

                MapComponent component = (instance as MapComponent)!;
                prop.SetValue(this, instance);
                component.Parent = this;
                component.View = View;

                if (refResult is not null)
                {
                    JsComponentReference = refResult;
                    
                    // register this type in JS
                    await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorObject",
                        CancellationTokenSource.Token, component.JsComponentReference, component.Id);
                }

                ModifiedParameters[propertyName] = component;

                return instance;
            }

            // non MapComponent, return value from JS
            if (typeof(T).IsValueType)
            {
                object? objectResult = await CoreJsModule!.InvokeAsync<object?>("getProperty",
                    CancellationTokenSource.Token, JsComponentReference, propertyName.ToLowerFirstChar());

                if (objectResult is JsonElement jsonResult)
                {
                    if (typeof(T) == typeof(bool?))
                    {
                        instance = (T)(object)jsonResult.GetBoolean();
                    }
                    else if (typeof(T) == typeof(int?))
                    {
                        instance = (T)(object)jsonResult.GetInt32();
                    }
                    else if (typeof(T) == typeof(long?))
                    {
                        instance = (T)(object)jsonResult.GetInt64();
                    }
                    else if (typeof(T) == typeof(double?))
                    {
                        instance = (T)(object)jsonResult.GetDouble();
                    }
                    else if (typeof(T) == typeof(DateTime?))
                    {
                        instance = (T)(object)jsonResult.GetDateTime();
                    }
                    else
                    {
                        instance = (T)(object)jsonResult.GetString()!;
                    }
                }
                else
                {
                    instance = objectResult is null ? default : (T)objectResult;
                }
            }
            else
            {
                instance = await CoreJsModule!.InvokeAsync<T?>("getProperty",
                    CancellationTokenSource.Token, JsComponentReference, propertyName.ToLowerFirstChar());
            }
            prop.SetValue(this, instance);
            ModifiedParameters[propertyName] = instance;

            return instance;
        }
        catch (TaskCanceledException)
        {
            // do nothing, task was cancelled
            return currentValue;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error calling GetProperty for property {propertyName} on component {GetType().Name}: {ex}");
            return currentValue;
        }
    }

    /// <summary>
    ///     Called from <see cref="MapComponent.OnInitializedAsync" /> to "Register" the current component with its parent.
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
    ///     Toggles the visibility of the component.
    /// </summary>
    /// <param name="visible">
    ///     The new value to set for visibility of the component.
    /// </param>
    public Task SetVisible(bool visible)
    {
        return SetVisibility(visible);
    }
    
    /// <summary>
    ///     Retrieves the current value of the <see cref="Visible" /> property.
    /// </summary>
    public async Task<bool?> GetVisible()
    {
        if (CoreJsModule is null) return Visible;
        
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return Visible;
        
        bool? result = await CoreJsModule.InvokeAsync<bool?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "visible");
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Visible = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Visible)] = Visible;
        }
        
        return Visible;
    }
    
    /// <summary>
    ///     The reference to the .NET object that represents the component.
    /// </summary>
    [JsonConverter(typeof(DotNetObjectReferenceJsonConverter))]
    public DotNetObjectReference<MapComponent> DotNetComponentReference => DotNetObjectReference.Create(this);

    /// <summary>
    ///     The reference to the JavaScript object that represents the component.
    /// </summary>
    internal IJSObjectReference? JsComponentReference { get; set; }
    
    /// <summary>
    ///     For internal use, registration from JavaScript.
    /// </summary>
    [JSInvokable]
    public virtual async ValueTask<MapComponent?> OnJsComponentCreated(IJSObjectReference jsComponentReference, 
        IJSStreamReference jsonStreamReference)
    {
        JsComponentReference = jsComponentReference;
        MapComponent? instantiatedComponent = null;

        try
        {
            await using Stream stream = await jsonStreamReference
                .OpenReadStreamAsync(1_000_000_000L);
            await using MemoryStream ms = new();
            await stream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            byte[] encodedJson = ms.ToArray();
            string instantiatedComponentJson = Encoding.UTF8.GetString(encodedJson);
            Type componentType = GetType();
            // deserialize to this type
            JsonSerializerOptions options = GeoBlazorSerialization.JsonSerializerOptions;

            if (JsonSerializer.Deserialize(instantiatedComponentJson, componentType, options) 
                is MapComponent deserialized)
            {
                instantiatedComponent = deserialized;
                CopyProperties(instantiatedComponent);
            }

            // we can't serialize the already-serialized sourceJSON, so we call this separately
            if (componentType.GetMethod("GetSourceJSON") is { } getSourceJSONMethod)
            {
                getSourceJSONMethod.Invoke(this, []);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error deserializing instantiated component: {ex}");
        }
        
        return instantiatedComponent;
    }

    internal void CopyProperties(MapComponent deserializedComponent)
    {
        foreach (PropertyInfo prop in GetType().GetProperties()
            .Where(p => p.SetMethod is not null))
        {
            if (prop.Name == nameof(CoreJsModule)
                || prop.Name == nameof(Layer)
                || prop.Name == nameof(View))
            {
                continue;
            }
            
            CopyProperty(prop, deserializedComponent);
        }
    }

    private void CopyProperty(PropertyInfo prop, MapComponent deserializedComponent)
    {
        object? newValue = prop.GetValue(deserializedComponent);
        if (newValue is null)
        {
            return;
        }
            
        object? currentValue = prop.GetValue(this);

        if (currentValue is not null 
            && (currentValue is not IEnumerable collection || collection.Cast<object>().Any())
            && currentValue is not MapComponent)
        {
            // don't overwrite existing values and non-empty collections
            return;
        }
            
        if (currentValue is MapComponent currentPropComponent)
        {
            currentPropComponent.CoreJsModule = CoreJsModule;
            currentPropComponent.View = View;
            currentPropComponent.Layer = Layer;
            currentPropComponent.Parent = this;
            currentPropComponent.CopyProperties((MapComponent)newValue);
        }
        else
        {
            prop.SetValue(this, newValue);
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
    public virtual void ValidateRequiredChildren()
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
    public virtual void ValidateRequiredGeneratedChildren()
    {
        
    }

    /// <summary>
    ///     Reflection-based properties of the component.
    /// </summary>
    protected PropertyInfo[]? Props;

    /// <summary>
    ///     Identifies whether this component has been checked for valid and required properties/children.
    /// </summary>
    protected bool IsValidated;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        
        if (Parent is not null && !_registered)
        {
            if (!await Parent.RegisterGeneratedChildComponent(this))
            {
                await Parent.RegisterChildComponent(this);
            }
            
            if (Parent is Layer layer)
            {
                Layer = layer;
            }
            else
            {
                Layer ??= Parent.Layer;
            }
            
            View ??= Parent.View;
            _registered = true;
        }
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        
        _layerId ??= Layer?.Id;

        if (_layerId is not null && Layer is null && View?.Map is not null)
        {
            foreach (Layer layer in View.Map.Layers)
            {
                if (layer.Id == _layerId)
                {
                    Layer = layer;
                    break;
                }

                if (layer is IGroupLayer { Layers: not null } groupLayer)
                {
                    foreach (Layer subLayer in groupLayer.Layers)
                    {
                        if (subLayer.Id == _layerId)
                        {
                            Layer = subLayer;
                            break;
                        }
                    }
                }
            }
        }
        
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
            ProJsModule ??= await JsModuleManager!.GetArcGisJsPro(JsRuntime!, CancellationToken.None);
            CoreJsModule ??= await JsModuleManager!.GetArcGisJsCore(JsRuntime!, ProJsModule, CancellationToken.None);
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
    ///     The previous parameters that were set in the component.
    /// </summary>
    protected internal Dictionary<string, object?>? PreviousParameters;

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
    protected void UpdateState()
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
    protected internal bool IsRenderedBlazorComponent;
    private bool _registered;
    private IJSObjectReference? _coreJsModule;
    private IJSObjectReference? _proJsModule;
    private Guid? _layerId;
    private Guid? _viewId;

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
            JsonSerializerOptions options = GeoBlazorSerialization.JsonSerializerOptions;

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
                DotNetComponentReference);

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
            JsonSerializerOptions options = GeoBlazorSerialization.JsonSerializerOptions;

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
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), GeoBlazorSerialization.JsonSerializerOptions));
    }
}

internal record MapComponentSerializationRecord;