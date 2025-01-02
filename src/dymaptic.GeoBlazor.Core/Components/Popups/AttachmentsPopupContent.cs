namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     An AttachmentsContent popup element represents an attachment element associated with a feature. This resource is
///     available only if the FeatureLayer.capabilities.data.supportsAttachment is true.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class AttachmentsPopupContent : PopupContent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public AttachmentsPopupContent()
    {
    }
    
    /// <summary>
    ///     Constructor for creating a AttachmentsPopupContent in code.
    /// </summary>
    /// <param name="title">
    ///     A heading indicating what the attachment's content represents.
    /// </param>
    /// <param name="description">
    ///     Describes the attachment's content in detail.
    /// </param>
    /// <param name="displayType">
    ///     A string value indicating how to display an attachment.
    /// </param>
    public AttachmentsPopupContent(string? title = null, string? description = null, 
        AttachmentsPopupContentDisplayType? displayType = null)
    {
#pragma warning disable BL0005
        Title = title;
        Description = description;
        DisplayType = displayType;
#pragma warning restore BL0005
    }
    
    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Attachments;

    /// <summary>
    ///     Describes the attachment's content in detail.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     A string value indicating how to display an attachment.
    ///     default "auto"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-AttachmentsContent.html#displayType">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public AttachmentsPopupContentDisplayType? DisplayType { get; set; }

    /// <summary>
    ///     A heading indicating what the attachment's content represents.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Asynchronously retrieve the current value of the DisplayType property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<AttachmentsPopupContentDisplayType?> GetDisplayType()
    {
        if (CoreJsModule is null)
        {
            return DisplayType;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return DisplayType;
        }

        // get the property value
#pragma warning disable BL0005
        DisplayType = await CoreJsModule!.InvokeAsync<AttachmentsPopupContentDisplayType?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "displayType");
#pragma warning restore BL0005
        return DisplayType;
    }
    
    /// <summary>
    ///    Asynchronously set the value of the DisplayType property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetDisplayType(AttachmentsPopupContentDisplayType value)
    {
#pragma warning disable BL0005
        DisplayType = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(DisplayType)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "displayType", value);
    }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type.ToString().ToKebabCase())
        {
            Description = Description,
            DisplayType = DisplayType?.ToString().ToKebabCase(),
            Title = Title
        };
    }
}