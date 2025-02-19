namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The content displayed in the ListItem panel.
/// </summary>
[CodeGenerationIgnore]
public class ListItemPanelContent : MapComponent
{
    /// <summary>
    ///     The content of the panel as a string.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StringContent { get; set; }
    
    /// <summary>
    ///     The content of the panel as a Widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Widget? WidgetContent { get; set; }
    
    /// <summary>
    ///     The content of the panel as an HTMLElement.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ElementReference? HtmlElementContent { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Widget widget:
                WidgetContent = widget;
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
            case Widget widget:
                if (WidgetContent == widget)
                {
                    WidgetContent = null;
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        WidgetContent?.ValidateRequiredChildren();
    }
}
