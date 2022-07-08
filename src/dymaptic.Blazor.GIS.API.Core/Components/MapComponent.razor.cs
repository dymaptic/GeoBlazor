using dymaptic.Blazor.GIS.API.Core.Components.Views;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;
using dymaptic.Blazor.GIS.API.Core.Exceptions;


namespace dymaptic.Blazor.GIS.API.Core.Components;

[JsonConverter(typeof(MapComponentConverter))]
public abstract partial class MapComponent : ComponentBase, IDisposable
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

    public virtual void Dispose()
    {
        Parent?.UnregisterChildComponent(this);
    }

    public virtual Task RegisterChildComponent(MapComponent child)
    {
        throw new InvalidChildElementException(GetType().Name, child.GetType().Name);
    }

    public virtual Task UnregisterChildComponent(MapComponent child)
    {
        throw new NotImplementedException();
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

    public virtual Task RemoveComponent()
    {
        return Task.CompletedTask;
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