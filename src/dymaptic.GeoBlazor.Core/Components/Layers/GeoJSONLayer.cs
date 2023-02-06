using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The GeoJSONLayer class is used to create a layer based on GeoJSON. GeoJSON is a format for encoding a variety of geographic data structures. The GeoJSON data must comply with the RFC 7946 specification which states that the coordinates are in SpatialReference.WGS84.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html">ArcGIS JS API</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/interactive-projection">Sample - Display Projection</a>
/// </example>
public class GeoJSONLayer : Layer
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public GeoJSONLayer()
    {
    }

    /// <summary>
    ///     Constructs a new GeoJSONLayer in code with parameters
    /// </summary>
    /// <param name="url">
    ///     The url for the GeoJSON source data.
    /// </param>
    /// <param name="copyright">
    ///     A copyright string to identify ownership of the data.
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the Legend and LayerList widgets.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is referenced in a view, but its features will not be visible in the view.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    public GeoJSONLayer(string? url = null, string? copyright = null, string? title = null,
        double? opacity = null, bool? visible = null, ListMode? listMode = null)
    {
        Url = url;
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;
    }
    
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string LayerType => "geo-json";

    /// <summary>
    ///     The url for the GeoJSON source data.
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
    ///     The <see cref="SpatialReference"/> to render the GeoJSON data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <summary>
    ///     The <see cref="Renderer"/> that defines how the GeoJSON data will be displayed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Renderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                    await UpdateComponent();
                }

                break;
            case SpatialReference spatialReference:
                if (!spatialReference.Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
                    await UpdateComponent();
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
            case Renderer _:
                Renderer = null;

                break;
            case SpatialReference _:
                SpatialReference = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}