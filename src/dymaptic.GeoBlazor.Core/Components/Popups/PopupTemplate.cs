namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class PopupTemplate : MapComponent, IProtobufSerializable<PopupTemplateSerializationRecord>
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public PopupTemplate()
    {
    }

    /// <summary>
    ///     Constructs a new PopupTemplate in code with parameters
    /// </summary>
    /// <param name="title">
    ///     The title of the popup
    /// </param>
    /// <param name="stringContent">
    ///     Use this parameter if the content is a simple string
    /// </param>
    /// <param name="outFields">
    ///     An array of field names used in the PopupTemplate.
    /// </param>
    /// <param name="fieldInfos">
    ///     An array of FieldInfo that defines how fields in the dataset or values from Arcade expressions participate in a popup.
    /// </param>
    /// <param name="content">
    ///     Pass advanced <see cref="PopupContent" /> parameters
    /// </param>
    /// <param name="expressionInfos">
    ///     An array of objects or ExpressionInfo[] that reference Arcade expressions following the specification defined by the Arcade Popup Profile.
    /// </param>
    /// <param name="overwriteActions">
    ///     Indicates whether actions should replace existing popup actions.
    /// </param>
    /// <param name="returnGeometry">
    ///     Indicates whether to include the feature's geometry for use by the template.
    /// </param>
    /// <param name="actions">
    ///     Defines actions that may be executed by clicking the icon or image symbolizing them in the popup
    /// </param>
    [CodeGenerationIgnore]
    public PopupTemplate(string? title = null, string? stringContent = null, IReadOnlyList<string>? outFields = null,
        IReadOnlyList<FieldInfo>? fieldInfos = null, IReadOnlyList<PopupContent>? content = null,
        IReadOnlyList<PopupExpressionInfo>? expressionInfos = null, bool? overwriteActions = null,
        bool? returnGeometry = null, IReadOnlyList<ActionBase>? actions = null)
    {
#pragma warning disable BL0005
        Title = title;
        StringContent = stringContent;
        OutFields = outFields;
        OverwriteActions = overwriteActions;
        ReturnGeometry = returnGeometry;

        if (content is not null)
        {
            Content = content.ToList();
        }

        if (fieldInfos is not null)
        {
            FieldInfos = fieldInfos.ToList();
        }

        if (expressionInfos is not null)
        {
            ExpressionInfos = expressionInfos.ToList();
        }

        if (actions is not null)
        {
            Actions = actions.ToList();
        }
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The template for defining and formatting a popup's content, provided as a simple string.
    /// </summary>
    /// <remarks>
    ///     Either <see cref="Content" /> or <see cref="StringContent" /> should be defined, but not both.
    /// </remarks>
    [Parameter]
    [RequiredProperty(nameof(Content), nameof(ContentFunction))]
    public string? StringContent { get; set; }

    /// <summary>
    ///     The template for defining how to format the title used in a popup.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }


    /// <summary>
    ///     Indicates whether actions should replace existing popup actions.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OverwriteActions { get; set; }

    /// <summary>
    ///     Indicates whether to include the feature's geometry for use by the template. This property should be set to true if needing to access the popup's selected feature's geometry. Access the geometry via the returned graphic from the popup's selectedFeatureWidget. This is needed since the geometry is not automatically queried and returned in the popup's selected feature.
    ///     If the feature layer does not specify its outFields and the template's outFields isn't set, the returned popup's
    ///     geometry is only returned if returnGeometry is set to true. This also applies when working with WebMaps.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnGeometry { get; set; }
    
    /// <summary>
    ///     Defines a delegate function which will generate the <see cref="PopupContent"/>s for the template.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [RequiredProperty(nameof(Content), nameof(StringContent))]
    public Func<Graphic, ValueTask<PopupContent[]?>>? ContentFunction { get; set; }
    
    /// <summary>
    ///     Identifies that the <see cref="ContentFunction"/> is defined.
    /// </summary>
    public bool HasContentFunction => ContentFunction is not null;

    /// <summary>
    ///     The template for defining and formatting a popup's content, provided as a collection of <see cref="PopupContent" /> s.
    /// </summary>
    /// <remarks>
    ///     Either <see cref="Content" /> or <see cref="StringContent" /> should be defined, but not both.
    /// </remarks>
    [RequiredProperty(nameof(StringContent), nameof(ContentFunction))]
    [CodeGenerationIgnore]
    [Parameter]
    public IReadOnlyList<PopupContent>? Content { get; set; }

    /// <summary>
    ///     JS-invokable method for triggering actions.
    /// </summary>
    /// <param name="triggerActionEvent">
    ///     The event that contains the action to be triggered.
    /// </param>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsTriggerAction(PopupTriggerActionEvent triggerActionEvent)
    {
        await OnTriggerAction.InvokeAsync(triggerActionEvent);
    }
    
    /// <summary>
    ///     Event Listener for TriggerAction.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<PopupTriggerActionEvent> OnTriggerAction { get; set; }
    
    /// <summary>
    ///     JS-invokable method that triggers a custom <see cref="ContentFunction"/> for building the popup content.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    public async Task<PopupContent[]?> OnJsContentFunction(Graphic graphic)
    {
        PopupContent[]? content = null;

        if (ContentFunction is not null)
        {
            content = await ContentFunction.Invoke(graphic);
        }
        
        return content;
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupContent popupContent:
                Content ??= [];
                Content = [..Content, popupContent];

                break;
            case FieldInfo fieldInfo:
                FieldInfos ??= [];
                FieldInfos = [..FieldInfos, fieldInfo];

                break;
            case ActionBase action:
                Actions ??= [];
                Actions = [..Actions, action];

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
            case PopupContent popupContent:
                Content = Content?.Except([popupContent]).ToList();

                break;
            case FieldInfo fieldInfo:
                FieldInfos = FieldInfos?.Except([fieldInfo]).ToList();

                break;
            case ActionBase action:
                Actions = Actions?.Except([action]).ToList();

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

        if (Content is not null)
        {
            foreach (PopupContent item in Content)
            {
                item.ValidateRequiredChildren();
            }
        }

    }

    public PopupTemplateSerializationRecord ToProtobuf()
    {
        return new PopupTemplateSerializationRecord(Title, StringContent, OutFields,
            FieldInfos?.Select(f => f.ToProtobuf()),
            Content?.Select(c => c.ToProtobuf()),
            ExpressionInfos?.Select(e => e.ToProtobuf()), OverwriteActions,
            ReturnGeometry, Actions?.Select(a => a.ToProtobuf()), Id.ToString());
    }
}