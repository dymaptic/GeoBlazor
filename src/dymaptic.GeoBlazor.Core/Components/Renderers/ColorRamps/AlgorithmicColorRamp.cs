﻿using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers.ColorRamps;

/// <summary>
///     Creates a color ramp for use in a raster renderer. The algorithmic color ramp is defined by specifying two colors and the
///     algorithm used to traverse the intervening color spaces.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AlgorithmicColorRamp.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class AlgorithmicColorRamp : ColorRamp
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public AlgorithmicColorRamp() { }

    public AlgorithmicColorRamp(Algorithm algorithm, MapColor? fromColor, MapColor? toColor)
    {
        Algorithm = algorithm;
        FromColor = fromColor;
        ToColor = toColor;
    }
    /// <inheritdoc />
    /// <summary>
    ///     A string value representing the color ramp type.
    /// </summary>
    [JsonPropertyName("type")]
    public override ColorRampType ColorRampType => ColorRampType.Algorithmic;

    /// <summary>
    ///     The algorithm used to generate the colors between the fromColor and toColor.
    /// </summary>
    [Parameter]
    public Algorithm Algorithm { get; set; }

    /// <summary>
    ///     The first color in the color ramp.
    /// </summary>
    [Parameter]
    public MapColor? FromColor { get; set; }

    /// <summary>
    ///     The last color in the color ramp.
    /// </summary>
    [Parameter]
    public MapColor? ToColor { get; set; }

}

/// <summary>
///     The algorithms used to generate the colors between the fromColor and toColor. Each algorithm uses different methods for generating the intervening colors.
///     Read more in the link above.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<Algorithm>))]
public enum Algorithm
{
    CieLab,
    LabLch,
    Hsv
}