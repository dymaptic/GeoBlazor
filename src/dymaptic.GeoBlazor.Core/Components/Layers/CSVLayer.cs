using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The CSVLayer is a point layer based on a CSV file (.csv, .txt). CSV is a plain-text file format used to
///     represent tabular data, including geographic point features (latitude, longitude). Typically the latitude
///     coordinate is the Y value, and the longitude coordinate is the X value. The X, Y coordinates must be stored
///     in SpatialReference.WGS84 in csv feed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class CSVLayer : Layer
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
    public CSVLayer(string url, string? title = null, string? copyright = null,
        double? opacity = null, bool? visible = null, ListMode? listMode = null)
    {
#pragma warning disable BL0005
        Url = url;
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;
        Copyright = copyright;
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
}