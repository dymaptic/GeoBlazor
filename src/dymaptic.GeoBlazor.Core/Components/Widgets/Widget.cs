using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The base class for widgets. Each widget's presentation is separate from its properties, methods, and data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Widget.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
[JsonConverter(typeof(WidgetConverter))]
public abstract class Widget : MapComponent
{
    /// <summary>
    ///     The position of the widget in relation to the map view.
    /// </summary>
    /// <remarks>
    ///     Either <see cref="Position" /> or <see cref="ContainerId" /> should be set, but not both.
    /// </remarks>
    [Parameter]
    public OverlayPosition? Position { get; set; }

    /// <summary>
    ///     The id of an external HTML Element (div). If provided, the widget will be placed inside that element, instead of on
    ///     the map.
    /// </summary>
    /// <remarks>
    ///     Either <see cref="Position" /> or <see cref="ContainerId" /> should be set, but not both.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ContainerId { get; set; }

    /// <summary>
    ///     The type of widget
    /// </summary>
    [JsonPropertyName("type")]
    public abstract string WidgetType { get; }

    /// <summary>
    ///     DotNet Object Reference to the widget
    /// </summary>
    public DotNetObjectReference<Widget> DotNetWidgetReference => DotNetObjectReference.Create(this);

    /// <summary>
    ///     JS-invokable callback to register a JS Object Reference
    /// </summary>
    [JSInvokable]
    public void OnWidgetCreated(IJSObjectReference jsObjectReference)
    {
        JsObjectReference = jsObjectReference;
    }

    /// <summary>
    ///     JS Object Reference to the widget
    /// </summary>
    protected IJSObjectReference? JsObjectReference;
}

internal class WidgetConverter : JsonConverter<Widget>
{
    public override Widget Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Widget value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), options));
    }
}