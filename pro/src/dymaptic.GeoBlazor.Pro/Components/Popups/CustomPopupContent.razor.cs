namespace dymaptic.GeoBlazor.Pro.Components.Popups;

[CodeGenerationIgnore]
public partial class CustomPopupContent: PopupContent
{
    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Custom;

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Popups.CustomPopupContent.html#custompopupcontentpopuptemplatecontentcreator-property">GeoBlazor Docs</a>
    ///     The function that is called to create the custom content element.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-CustomContent.html#creator">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public PopupTemplateContentCreator? CreatorFunction { get; set; }
    
    /// <summary>
    ///     JS-invokable method that triggers the <see cref="CreatorFunction"/> function.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task<string?> OnJsPopupTemplateContentCreator(IJSStreamReference jsStreamReference)
    {
        PopupTemplateCreatorEvent? creatorEvent = await jsStreamReference.ReadJsStreamReference<PopupTemplateCreatorEvent>();
        
        string? result = null;
    
        if (CreatorFunction is not null && creatorEvent is not null)
        {
            result = await CreatorFunction.Invoke(creatorEvent);
        }
        
        return result;
    }
    
    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="CreatorFunction" /> function was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasContentCreatorFunction => CreatorFunction is not null;
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Popups.CustomPopupContent.html#custompopupcontentdestroyer-property">GeoBlazor Docs</a>
    ///     The called function to cleanup custom content when it is no longer necessary.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-CustomContent.html#destroyer">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public PopupTemplateContentDestroyer? Destroyer { get; set; }
    
    /// <summary>
    ///     JS-invokable method that triggers the <see cref="Destroyer"/> function.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsDestroyer(PopupTemplateCreatorEvent destroyerEvent)
    {
        if (Destroyer is not null)
        {
            await Destroyer.Invoke(destroyerEvent);
        }
    }
    
    /// <summary>
    ///     A convenience property that signifies whether a custom <see cref="Destroyer" /> function was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasDestroyerFunction => Destroyer is not null;
    
    /// <summary>
    ///     Widget child content.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public Widget? WidgetContent { get; set; }

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

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase())
        {
            OutFields = OutFields?.ToArray()
        };
    }
}