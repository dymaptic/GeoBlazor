using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;

/// <summary>
///     Creates a color ramp for use in a raster renderer. The algorithmic color ramp is defined by specifying two colors and the
///     algorithm used to traverse the intervening color spaces.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-MultipartColorRamp.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class MultipartColorRamp : ColorRamp
{
    public MultipartColorRamp() { }
    /// <summary>
    ///     A string value representing the color ramp type.
    /// </summary>
    [JsonPropertyName("type")]
    [Parameter]
    public string? Type { get; set; }

    public AlgorithmicColorRamp[]? ColorRamps { get; set; }

    ///// <inheritdoc />
    //public override async Task RegisterChildComponent(MapComponent child)
    //{
    //    switch (child)
    //    {
    //        case AlgorithmicColorRamp algorithmicColorRamp:
    //            if (!algorithmicColorRamp.Equals(ColorRamps))
    //            {
    //                ColorRamps = algorithmicColorRamp;
    //                LayerChanged = true;
    //            }
    //            break;
    //        default:
    //            await base.RegisterChildComponent(child);

    //            break;
    //    }
    //}
    ///// <inheritdoc />
    //public override async Task UnregisterChildComponent(MapComponent child)
    //{
    //    switch (child)
    //    {
    //        case AlgorithmicColorRamp _:
    //            ColorRamps = null;
    //            LayerChanged = true;
    //            break;
    //        default:
    //            await base.UnregisterChildComponent(child);

    //            break;
    //    }
    //}
    ///// <inheritdoc />
    //internal override void ValidateRequiredChildren()
    //{
    //    Type?.ValidateRequiredChildren();
    //    base.ValidateRequiredChildren();
    //}
}
