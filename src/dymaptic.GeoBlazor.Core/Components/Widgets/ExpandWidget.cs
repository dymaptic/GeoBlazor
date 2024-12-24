namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Expand widget acts as a clickable button for opening a widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Expand.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ExpandWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Expand;

    /// <summary>
    ///     Internal mark for GeoBlazor rendering
    /// </summary>
    protected override bool Hidden => true;
    
    /// <summary>
    ///     Tooltip to display to indicate Expand widget can be expanded
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
    ///     The custom HTML content to display within the expanded Expand widget.
    /// </summary>
    /// <remarks>
    ///     You can now define custom HTML inline in Razor markup inside an Expand widget, instead of using this parameter. 
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HtmlContent { get; set; }

    /// <summary>
    ///     The content to display within the expanded Expand widget.
    /// </summary>
    /// <remarks>
    ///     If adding a Slider, HistogramRangeSlider, or TimeSlider as content to the Expand widget, the container or parent
    ///     container of the widget must have a width set in CSS for it to render inside the Expand widget.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Widget? WidgetContent { get; set; }

    /// <summary>
    ///     Indicates whether the widget is currently expanded or not.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Expanded { get; set; }

    /// <summary>
    ///    Calcite icon used when the widget is collapsed. Will automatically use the content's icon if it has one.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExpandIcon { get; set; }

    /// <summary>
    ///    Calcite icon used to style the Expand button when the content can be collapsed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CollapseIcon { get; set; }

    /// <summary>
    ///   The mode in which the widget displays.
    /// </summary>
    [Parameter]
    public ExpandMode Mode { get; set; } = ExpandMode.Auto;

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Widget widget:
                if (!widget.Equals(WidgetContent))
                {
                    WidgetContent = widget;
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
                WidgetContent = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}