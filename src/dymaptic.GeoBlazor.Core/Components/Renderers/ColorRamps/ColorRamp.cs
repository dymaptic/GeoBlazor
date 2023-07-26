using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;

/// <summary>
///     A ColorRamp object is used to specify a range of colors that are applied to a group of symbols or pixels.
///     There are two types of color ramps available:
///     Algorithmic color ramp: A AlgorithmicColorRamp is defined by two colors and the algorithm used to traverse the intervening color space between them.
///     Multipart color ramp: A MultipartColorRamp is defined by a list of constituent color ramps.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-ColorRamp.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class ColorRamp 
{
    public ColorRamp() { }
    /// <summary>
    ///     A string value representing the color ramp type.  Possible Values:"algorithmic"|"multipart"
    /// </summary>
    [JsonPropertyName("type")]
    [Parameter]
    public string? Type { get; set; }

    ///// <inheritdoc />
    //public override async Task RegisterChildComponent(MapComponent child)
    //{
    //    switch (child)
    //    {
    //        case colorRampType:
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
