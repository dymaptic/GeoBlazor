using dymaptic.GeoBlazor.Core.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Options for configuring the highlight. Use the highlight method on the appropriate LayerView to highlight a
///     feature. With version 4.19, highlighting a feature influences the shadow of the feature as well. By default, the
///     shadow of the highlighted feature is displayed in a darker shade.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#highlightOptions">ArcGIS Maps SDK for JavaScript (LayerView)</a>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#highlightOptions">ArcGIS Maps SDK for JavaScript (SceneView)</a>
/// </summary>
public class HighlightOptions : MapComponent
{
    /// <summary>
    ///     Default Constructor for use as a Blazor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public HighlightOptions()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    public HighlightOptions(MapColor? color = null, MapColor? haloColor = null, double? haloOpacity = null,
        double? fillOpacity = null, MapColor? shadowColor = null, double? shadowOpacity = null,
        double? shadowDifference = null)
    {
        Color = color;
        HaloColor = haloColor;
        HaloOpacity = haloOpacity;
        FillOpacity = fillOpacity;
        ShadowColor = shadowColor;
        ShadowOpacity = shadowOpacity;
        ShadowDifference = shadowDifference;
    }

    /// <summary>
    ///     The color of the highlight fill.
    ///     DefaultValue: #00ffff
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; set; }

    /// <summary>
    ///     The color of the halo surrounding the highlight. If no haloColor is provided, then the halo will be colored with
    ///     the specified color.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? HaloColor { get; set; }

    /// <summary>
    ///     The opacity of the highlight halo. This will be multiplied with any opacity specified in color.
    ///     DefaultValue: 1
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? HaloOpacity { get; set; }

    /// <summary>
    ///     The opacity of the fill (area within the halo). This will be multiplied with the opacity specified in color.
    ///     DefaultValue: 0.25
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? FillOpacity { get; set; }

    /// <summary>
    ///     The color of the highlighted feature's shadow.
    ///     DefaultValue: #000000
    /// </summary>
    /// <remarks>
    ///     Only supported on 3D scene views.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? ShadowColor { get; set; }

    /// <summary>
    ///     The opacity of the highlighted feature's shadow. This will be multiplied with the opacity specified in shadowColor.
    ///     DefaultValue: 0.4
    /// </summary>
    /// <remarks>
    ///     Only supported on 3D scene views.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ShadowOpacity { get; set; }

    /// <summary>
    ///     Defines the intensity of the shadow area obtained by overlapping the shadow of the highlighted feature and the
    ///     shadow of other objects in the scene. The value ranges from 0 to 1. A value of 0 highlights the overlapping shadow
    ///     areas in the same way (no difference). Setting it to 1 highlights only the difference between the shadow areas, so
    ///     the overlapping shadow areas aren't highlighted at all.
    ///     DefaultValue: 0.375
    /// </summary>
    /// <remarks>
    ///     Only supported on 3D scene views.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ShadowDifference { get; set; }
}