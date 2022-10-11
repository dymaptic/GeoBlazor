using dymaptic.GeoBlazor.Core.Components.Views;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Exceptions;
using System.Collections;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The abstract base Razor Component class that all GeoBlazor components derive from.
/// </summary>
[JsonConverter(typeof(MapComponentConverter))]
public abstract partial class MapComponent : ComponentBase, IAsyncDisposable
{
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
    ///     A boolean flag that indicates that the current <see cref="MapView"/> has finished rendering.
    ///     To listen for a map rendering event, use <see cref="MapView.OnMapRenderedHandler"/>.
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
    ///     The parent <see cref="MapView"/> of the current component.
    /// </summary>
    [CascadingParameter(Name = "View")]
    [JsonIgnore]
    public MapView? View { get; set; }
    
    /// <summary>
    ///     A unique identifier, used to track components across .NET and JavaScript.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    ///     Implements the `IAsyncDisposable` pattern.
    /// </summary>
    public virtual async ValueTask DisposeAsync()
    {
        if (Parent is not null)
        {
            await Parent.UnregisterChildComponent(this);
        }

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
    }

    /// <summary>
    ///     Called from <see cref="MapComponent.OnAfterRenderAsync"/> to "Register" the current component with it's parent.
    /// </summary>
    /// <param name="child">
    ///     The calling, child component to register
    /// </param>
    /// <exception cref="InvalidChildElementException">
    ///     Throws if the current child is not a valid sub-component to the parent.
    /// </exception>
    public virtual Task RegisterChildComponent(MapComponent child)
    {
        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    /// <summary>
    ///     Undoes the "Registration" of a child with its parent.
    /// </summary>
    /// <param name="child">
    ///     The child to unregister
    /// </param>
    public virtual Task UnregisterChildComponent(MapComponent child)
    {
        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    /// <summary>
    ///     Provides a way to externally call `StateHasChanged` on the component.
    /// </summary>
    public virtual void Refresh()
    {
        StateHasChanged();
    }

    /// <summary>
    ///     Checks if the map is already rendered, and if so, performs forced updates as defined by the component type.
    /// </summary>
    public virtual async Task UpdateComponent()
    {
        if (Parent is not null && MapRendered)
        {
            Console.WriteLine($"Updating {GetType().Name} with {Parent.GetType().Name}");
            await Parent.UpdateComponent();
        }
    }


    /// <summary>
    ///     When a <see cref="MapView" /> is prepared to render, this will check to make sure that all properties with the <see cref="RequiredPropertyAttribute"/> are provided.
    /// </summary>
    /// <exception cref="MissingRequiredChildElementException">
    ///     The consumer needs to provide the missing child component
    /// </exception>
    /// <exception cref="MissingRequiredOptionsChildElementException">
    ///     The consumer needs to provide ONE of the options of child components
    /// </exception>
    public virtual void ValidateRequiredChildren()
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
            RequiredPropertyAttribute attr =
                (RequiredPropertyAttribute)requiredParameter.GetCustomAttributes(
                    typeof(RequiredPropertyAttribute), true)[0];
            
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
                else
                {
                    continue;
                }
            }
            else if (value is null)
            {
                throw new MissingRequiredChildElementException(thisType.Name, propType.Name);
            }

            // lists, arrays
            if (propType.GetInterface(nameof(ICollection)) != null && ((ICollection)value).Count == 0)
            {
                throw new MissingRequiredChildElementException(thisType.Name, propType.Name);
            }
        }

        foreach (var option in options)
        {
            if (!option.Found)
            {
                throw new MissingRequiredOptionsChildElementException(thisType.Name, option.Options);
            }
        }
    }

    /// <inheritdoc />
    protected override Task OnParametersSetAsync()
    {
        _needsUpdate = true;

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender || _needsUpdate)
        {
            _needsUpdate = false;
            StateHasChanged();

            return;
        }

        if (Parent is not null)
        {
            await Parent.RegisterChildComponent(this);
        }
    }

    /// <summary>
    ///     Tells the <see cref="MapView"/> to completely re-render.
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

    private bool _needsUpdate;
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