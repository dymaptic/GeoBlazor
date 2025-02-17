namespace dymaptic.GeoBlazor.Core.Components.Popups;

public partial class PopupTemplate : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
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
    ///     An array of FieldInfo that defines how fields in the dataset or values from Arcade expressions participate in a
    ///     popup.
    /// </param>
    /// <param name="content">
    ///     Pass advanced <see cref="PopupContent" /> parameters
    /// </param>
    /// <param name="expressionInfos">
    ///     An array of objects or ExpressionInfo[] that reference Arcade expressions following the specification defined by
    ///     the Arcade Popup Profile.
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
    public PopupTemplate(string? title = null, string? stringContent = null, IReadOnlyList<string>? outFields = null,
        IReadOnlyList<FieldInfo>? fieldInfos = null, IReadOnlyList<PopupContent>? content = null,
        IReadOnlyList<ExpressionInfo>? expressionInfos = null, bool? overwriteActions = null,
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
    ///     Indicates whether to include the feature's geometry for use by the template. This property should be set to true if
    ///     needing to access the popup's selected feature's geometry. Access the geometry via the returned graphic from the
    ///     popup's selectedFeatureWidget. This is needed since the geometry is not automatically queried and returned in the
    ///     popup's selected feature.
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
    ///     The template for defining and formatting a popup's content, provided as a collection of <see cref="PopupContent" />
    ///     s.
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
    /// <param name="actionId">
    ///     The action ID.
    /// </param>
    [JSInvokable]
    public async Task OnTriggerAction(string actionId)
    {
        ActionBase? action = Actions?.FirstOrDefault(a => a.Id == actionId);

        if (action is not null)
        {
            await action.CallbackFunction!.Invoke();
        }
    }
    
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
            case ExpressionInfo expressionInfo:
                ExpressionInfos ??= [];
                ExpressionInfos = [..ExpressionInfos, expressionInfo];

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
            case ExpressionInfo expressionInfo:
                ExpressionInfos = ExpressionInfos?.Except([expressionInfo]).ToList();

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

    internal PopupTemplateSerializationRecord ToSerializationRecord()
    {
        return new PopupTemplateSerializationRecord(Title, StringContent, OutFields,
            FieldInfos?.Select(f => f.ToSerializationRecord()),
            Content?.Select(c => c.ToSerializationRecord()),
            ExpressionInfos?.Select(e => e.ToSerializationRecord()), OverwriteActions,
            ReturnGeometry, Actions?.Select(a => a.ToSerializationRecord()), Id.ToString());
    }
}

[ProtoContract(Name = "PopupTemplate")]
internal record PopupTemplateSerializationRecord : MapComponentSerializationRecord
{
    public PopupTemplateSerializationRecord()
    {
    }
    
    public PopupTemplateSerializationRecord(string? Title,
        string? StringContent = null,
        IEnumerable<string>? OutFields = null,
        IEnumerable<FieldInfoSerializationRecord>? FieldInfos = null,
        IEnumerable<PopupContentSerializationRecord>? Content = null,
        IEnumerable<ExpressionInfoSerializationRecord>? ExpressionInfos = null,
        bool? OverwriteActions = null,
        bool? ReturnGeometry = null,
        IEnumerable<ActionBaseSerializationRecord>? Actions = null,
        string? Id = null)
    {
        this.Title = Title;
        this.StringContent = StringContent;
        this.OutFields = OutFields;
        this.FieldInfos = FieldInfos;
        this.Content = Content;
        this.ExpressionInfos = ExpressionInfos;
        this.OverwriteActions = OverwriteActions;
        this.ReturnGeometry = ReturnGeometry;
        this.Actions = Actions;
        this.Id = Id;
    }

    public PopupTemplate FromSerializationRecord()
    {
        return new PopupTemplate(Title, StringContent, OutFields?.ToList(),
            FieldInfos?.Select(f => f.FromSerializationRecord()).ToList(),
            Content?.Select(c => c.FromSerializationRecord()).ToList(),
            ExpressionInfos?.Select(e => e.FromSerializationRecord()).ToList(), 
            OverwriteActions, ReturnGeometry, 
            Actions?.Select(a => a.FromSerializationRecord()).ToList());
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Title { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? StringContent { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public IEnumerable<string>? OutFields { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public IEnumerable<FieldInfoSerializationRecord>? FieldInfos { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public IEnumerable<PopupContentSerializationRecord>? Content { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public IEnumerable<ExpressionInfoSerializationRecord>? ExpressionInfos { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public bool? OverwriteActions { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(8)]
    public bool? ReturnGeometry { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(9)]
    public IEnumerable<ActionBaseSerializationRecord>? Actions { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(10)]
    public string? Id { get; init; }
}