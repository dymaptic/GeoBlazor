using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     Provides a simple widget that switches the View to its initial Viewpoint or a previously defined viewpoint.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Home.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class HomeWidget : Widget
{
    /// <inheritdoc />
    public override string WidgetType => "home";

    /// <summary>
    ///     The widget's default CSS icon class.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Obsolete("Use Icon instead")]
    public string? IconClass { get; set; }

    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
}