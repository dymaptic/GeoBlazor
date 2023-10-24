using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The CSVLayer is a point layer based on a CSV file (.csv, .txt). CSV is a plain-text file format used to
///     represent tabular data, including geographic point features (latitude, longitude). Typically the latitude
///     coordinate is the Y value, and the longitude coordinate is the X value. The X, Y coordinates must be stored
///     in SpatialReference.WGS84 in csv feed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class CSVLayer : Layer, IFeatureReductionLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public CSVLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The url for the CSV source data.
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the Legend and LayerList widgets.
    /// </param>
    /// <param name="copyright">
    ///     A copyright string to identify ownership of the data.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is
    ///     referenced in a view, but its features will not be visible in the view.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what
    ///     seems like a new layer.
    /// </param>
    /// <param name="popupTemplate">
    ///     A PopupTemplate allows you to specify the content that appears in the popup dialog window.
    /// </param>
    public CSVLayer(string url, string? title = null, string? copyright = null,
        double? opacity = null, bool? visible = null, ListMode? listMode = null,
        BlendMode? blendMode = null, PopupTemplate? popupTemplate = null)
    {
#pragma warning disable BL0005
        Url = url;
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;
        Copyright = copyright;
        BlendMode = blendMode;
        PopupTemplate = popupTemplate;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "csv";

    /// <summary>
    ///     The url for the GeoRSS source data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    /// <summary>
    ///     A copyright string to identify ownership of the data.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }
    
    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what
    ///     seems like a new layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }
    
    /// <summary>
    ///     The column delimiter. Default is comma (,).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CSVDelimiter? Delimiter { get; set; }
    
    /// <summary>
    ///     The name of the layer's primary display field. The value of this property matches the name of one of the fields of the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayField { get; set; }
    
    /// <summary>
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }
    
    /// <summary>
    ///     The renderer assigned to the layer. The renderer defines how to visualize each feature in the layer. Depending on the renderer type, features may be visualized with the same symbol, or with varying symbols based on the values of provided attribute fields or functions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                }

                break;
            case Renderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupTemplate _:
                PopupTemplate = null;

                break;
            case Renderer _:
                Renderer = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        PopupTemplate?.ValidateRequiredChildren();
        Renderer?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Possible Column Delimiters for CSVLayer
/// </summary>
[JsonConverter(typeof(CSVDelimiterConverter))]
public enum CSVDelimiter
{
#pragma warning disable CS1591
    Comma,
    Space,
    Semicolon,
    Pipe,
    TabDelimited
#pragma warning restore CS1591
}

internal class CSVDelimiterConverter : JsonConverter<CSVDelimiter>
{
    public override CSVDelimiter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, CSVDelimiter value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case CSVDelimiter.Comma:
                writer.WriteStringValue(",");

                break;
            case CSVDelimiter.Space:
                writer.WriteStringValue(" ");

                break;
            case CSVDelimiter.Semicolon:
                writer.WriteStringValue(";");

                break;
            case CSVDelimiter.Pipe:
                writer.WriteStringValue("|");

                break;
            case CSVDelimiter.TabDelimited:
                writer.WriteStringValue("\t");

                break;
        }
    }
}