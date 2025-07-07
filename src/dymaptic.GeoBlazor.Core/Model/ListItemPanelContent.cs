namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Represents the content of a ListItem panel, which can be a <see cref="string"/>, <see cref="Widget"/>, or an <see cref="ElementReference"/>.
/// </summary>
[CodeGenerationIgnore]
public record ListItemPanelContent
{
    /// <summary>
    ///     Constructs a new ListItemPanelContent from a string.
    /// </summary>
    public ListItemPanelContent(string stringContent)
    {
        StringContent = stringContent;
    }
    
    /// <summary>
    ///     Constructs a new ListItemPanelContent from a Widget.
    /// </summary>
    public ListItemPanelContent(Widget widgetContent)
    {
        WidgetContent = widgetContent;
    }
    
    /// <summary>
    ///     Constructs a new ListItemPanelContent from an HTMLElement reference.
    /// </summary>
    public ListItemPanelContent(ElementReference htmlElementContent)
    {
        HtmlElementContent = htmlElementContent;
    }

    /// <summary>
    ///     Implicit conversion from string to ListItemPanelContent.
    /// </summary>
    public static implicit operator ListItemPanelContent(string stringContent)
    {
        return new ListItemPanelContent(stringContent);
    }
    
    /// <summary>
    ///     Implicit conversion from Widget to ListItemPanelContent.
    /// </summary>
    public static implicit operator ListItemPanelContent(Widget widgetContent)
    {
        return new ListItemPanelContent(widgetContent);
    }
    
    /// <summary>
    ///     Implicit conversion from ElementReference to ListItemPanelContent.
    /// </summary>
    public static implicit operator ListItemPanelContent(ElementReference htmlElementContent)
    {
        return new ListItemPanelContent(htmlElementContent);
    }

    /// <summary>
    ///     Implicit conversion from ListItemPanelContent to string.
    /// </summary>
    public static implicit operator string?(ListItemPanelContent itemPanelContent)
    {
        return itemPanelContent.StringContent;
    }
    
    /// <summary>
    ///     Implicit conversion from ListItemPanelContent to Widget.
    /// </summary>
    public static implicit operator Widget?(ListItemPanelContent itemPanelContent)
    {
        return itemPanelContent.WidgetContent;
    }
    
    /// <summary>
    ///     Implicit conversion from ListItemPanelContent to ElementReference.
    /// </summary>
    public static implicit operator ElementReference?(ListItemPanelContent itemPanelContent)
    {
        return itemPanelContent.HtmlElementContent;
    }
    
    /// <summary>
    ///     The content of the panel as a string.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StringContent { get; set; }
    
    /// <summary>
    ///     The content of the panel as a Widget.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Widget? WidgetContent { get; set; }
    
    /// <summary>
    ///     The content of the panel as an HTMLElement.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ElementReference? HtmlElementContent { get; set; }
}