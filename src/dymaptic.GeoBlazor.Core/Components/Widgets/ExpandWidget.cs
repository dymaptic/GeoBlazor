using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Expand widget acts as a clickable button for opening a widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Expand.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class ExpandWidget : Widget
{
    /// <inheritdoc />
    public override string WidgetType => "expand";

    /// <summary>
    ///     Icon font used to style the Expand button when expanded.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExpandIconClass { get; set; }

    /// <summary>
    ///     Icon font used to style the Expand button when collapsed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CollapseIconClass { get; set; }

    /// <summary>
    ///     Tooltip to display to indicate Expand widget can be expanded.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExpandTooltip { get; set; }

    /// <summary>
    ///     Tooltip to display to indicate Expand widget can be collapsed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CollapseTooltip { get; set; }

    /// <summary>
    ///     Automatically collapses the expand widget instance when the view's viewpoint updates.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoCollapse { get; set; }

    /// <summary>
    ///     When true, the Expand widget will close after the Escape key is pressed when the keyboard focus is within its
    ///     content.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CloseOnEsc { get; set; }

    /// <summary>
    ///     The content to display within the expanded Expand widget.
    /// </summary>
    /// <remarks>
    ///     If adding a Slider, HistogramRangeSlider, or TimeSlider as content to the Expand widget, the container or parent
    ///     container of the widget must have a width set in CSS for it to render inside the Expand widget.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Widget? Content { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Widget widget:
                if (!widget.Equals(Content))
                {
                    Content = widget;
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
            case Widget _:
                Content = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}