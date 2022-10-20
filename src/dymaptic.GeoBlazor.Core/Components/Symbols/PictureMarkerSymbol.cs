using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     PictureMarkerSymbol renders Point graphics in either a 2D MapView or 3D SceneView using an image. A url must point to a valid image. PictureMarkerSymbols may be applied to point features in a FeatureLayer or individual graphics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-PictureMarkerSymbol.html">ArcGIS JS API</a>
/// </summary>
public class PictureMarkerSymbol : MarkerSymbol
{
    /// <summary>
    ///     The height of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Height { get; set; }

    /// <summary>
    ///     The width of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Width { get; set; }

    /// <inheritdoc />
    public override string Type => "picture-marker";

    /// <summary>
    ///     The URL to an image or SVG document.
    /// </summary>
    [Parameter]
    public string Url { get; set; } = default!;
}