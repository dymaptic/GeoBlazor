using dymaptic.GeoBlazor.Core.Components.Views;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Exceptions;
using System.Collections;
using System.Reflection;


namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(MapComponentConverter))]
public abstract partial class MapComponent : ComponentBase, IAsyncDisposable
{
    [Parameter]
    [JsonIgnore]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter(Name = "Parent")]
    [JsonIgnore]
    public MapComponent? Parent { get; set; }

    [CascadingParameter(Name = "MapRendered")]
    [JsonIgnore]
    public bool MapRendered { get; set; }

    [CascadingParameter(Name = "JsModule")]
    [JsonIgnore]
    public IJSObjectReference? JsModule { get; set; }

    [CascadingParameter(Name = "View")]
    [JsonIgnore]
    public MapView? View { get; set; }
    
    public Guid Id { get; init; } = Guid.NewGuid();

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

    public virtual Task RegisterChildComponent(MapComponent child)
    {
        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    public virtual Task UnregisterChildComponent(MapComponent child)
    {
        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    public virtual void Refresh()
    {
        StateHasChanged();
    }

    public virtual async Task UpdateComponent()
    {
        if (Parent is not null && MapRendered)
        {
            Console.WriteLine($"Updating {GetType().Name} with {Parent.GetType().Name}");
            await Parent.UpdateComponent();
        }
    }


    /// <summary>
    ///     When a <see cref="MapView" /> is prepared to render, this will check to make sure that
    ///     all properties with the <see cref="RequiredPropertyAttribute"/> are provided.
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

    protected override Task OnParametersSetAsync()
    {
        _needsUpdate = true;

        return Task.CompletedTask;
    }

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

    protected virtual async Task RenderView(bool forceRender = false)
    {
        if (Parent is not null)
        {
            await Parent.RenderView(forceRender);
        }
    }

    private bool _needsUpdate;
}

public class MapComponentConverter : JsonConverter<MapComponent>
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