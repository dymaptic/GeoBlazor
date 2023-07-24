using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

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
    /// <summary>
    ///     A string value representing the color ramp type.  Possible Values:"algorithmic"|"multipart"
    /// </summary>
    [JsonPropertyName("type")]
    [Parameter]
    public string? Type { get; set; }
}
