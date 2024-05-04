using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The GeoJSONLayer class is used to create a layer based on GeoJSON. GeoJSON is a format for encoding a variety of
///     geographic data structures. The GeoJSON data must comply with the RFC 7946 specification which states that the
///     coordinates are in SpatialReference.WGS84.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/pro-projection">Sample - Display Projection</a>
/// </example>
public class GeoJSONLayer : Layer, IFeatureReductionLayer, IPopupTemplateLayer
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
    ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is
    ///     referenced in a view, but its features will not be visible in the view.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    public GeoJSONLayer(string? url = null, string? copyright = null, string? title = null,
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
    ///     The <see cref="SpatialReference" /> to render the GeoJSON data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <summary>
    ///     The <see cref="Renderer" /> that defines how the GeoJSON data will be displayed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }
    
    /// <summary>
    ///     The popup template for the layer. When set on the layer, the popupTemplate allows users to access attributes and display their values in the view's popup when a feature is selected using text and/or charts. See the PopupTemplate sample for an example of how PopupTemplate interacts with a FeatureLayer.
    ///     A default popup template is automatically used if no popupTemplate has been defined when Popup.defaultPopupTemplateEnabled is set to true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Renderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                    LayerChanged = true;
                }

                break;
            case SpatialReference spatialReference:
                if (!spatialReference.Equals(SpatialReference))
                {
                    SpatialReference = spatialReference;
                    LayerChanged = true;
                }

                break;
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                    LayerChanged = true;
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
                LayerChanged = true;

                break;
            case SpatialReference _:
                SpatialReference = null;
                LayerChanged = true;

                break;
            case PopupTemplate _:
                PopupTemplate = null;
                LayerChanged = true;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    internal override void ValidateRequiredChildren()
    {
        Renderer?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
        SpatialReference?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}