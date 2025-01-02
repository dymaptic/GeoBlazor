using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
/// The AreaMeasurement2D widget calculates and displays the area and perimeter of a polygon in a MapView. 
/// How the area and perimeter are computed depends on the map’s spatial reference:n geographic coordinate systems(GCS) and in Web Mercator,
/// they are computed geodetically. In projected coordinate systems(PCS), apart from Web Mercator, they are computed in a 
/// Euclidean manner(in their respective PCS).
/// </summary>
public class AreaMeasurement2DWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override WidgetType Type => WidgetType.AreaMeasurement2D;

    /// <summary>
    ///     A .NET object reference for calling this class from JavaScript.
    /// </summary>
    public DotNetObjectReference<AreaMeasurement2DWidget> AreaMeasurement2DWidgetObjectReference => DotNetObjectReference.Create(this);

    /// <summary>
    /// Unit system (imperial, metric) or specific unit used for displaying the area values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AreaUnit Unit { get; set; }

    /// <summary>
    /// List of available units and unit systems (imperial, metric) for displaying the area values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AreaUnit[]? UnitOptions { get; set; }

}
