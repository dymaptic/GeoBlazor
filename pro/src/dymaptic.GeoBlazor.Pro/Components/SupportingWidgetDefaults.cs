namespace dymaptic.GeoBlazor.Pro.Components;

public partial class SupportingWidgetDefaults : MapComponent
{


    /// <summary>
    ///     An object containing properties specific for customizing the Attachments widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupportingWidgetAttachments? Attachments { get; set; }

    /// <summary>
    ///     An object containing properties specific for customizing the FeatureForm widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupportingWidgetFeatureForm? FeatureForm { get; set; }

    /// <summary>
    ///     An object containing properties specific for customizing the FeatureTemplates widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupportingWidgetFeatureTemplates? FeatureTemplates { get; set; }

    /// <summary>
    ///     An object containing properties specific for customizing the FeatureTemplates widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupportingWidgetSketch? Sketch { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SupportingWidgetAttachments attachments:
                Attachments = attachments;
                break;
            case SupportingWidgetFeatureForm featureForm:
                FeatureForm = featureForm;
                break;
            case SupportingWidgetFeatureTemplates featureTemplates:
                FeatureTemplates = featureTemplates;
                break;
            case SupportingWidgetSketch sketch:
                Sketch = sketch;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SupportingWidgetAttachments:
                Attachments = null;
                break;
            case SupportingWidgetFeatureForm:
                FeatureForm = null;
                break;
            case SupportingWidgetFeatureTemplates:
                FeatureTemplates = null;
                break;
            case SupportingWidgetSketch:
                Sketch = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override void ValidateRequiredChildren()
    {
        Attachments?.ValidateRequiredChildren();
        FeatureForm?.ValidateRequiredChildren();
        FeatureTemplates?.ValidateRequiredChildren();
        Sketch?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}


