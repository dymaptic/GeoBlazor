namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(ActionBaseConverter))]
[CodeGenerationIgnore]
public abstract partial class ActionBase : MapComponent
{
    /// <summary>
    ///     The title of the action.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Set this property to true to display a spinner icon. You should do this if the action executes an async operation, such as a query, that requires letting the end user know that a process is ongoing in the background. Set the property back to false to communicate to the user that the process has finished.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Active { get; set; }
    
    /// <summary>
    ///     This adds a CSS class to the ActionButton's node.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClassName { get; set; }

    /// <summary>
    ///     Indicates whether this action is disabled.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }

    /// <summary>
    ///     The action function to perform on click.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<Task>? CallbackFunction { get; set; }
    
    /// <summary>
    ///     Identifies whether the action has a callback function.
    /// </summary>
    public bool HasCallbackFunction => CallbackFunction != null;
    
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
        if (triggerActionEvent.Action.ActionId == ActionId)
        {
            await CallbackFunction!.Invoke();
        }
    }

    /// <summary>
    ///     Specifies the type of action. Choose between "button" or "toggle".
    /// </summary>
    public abstract string Type { get; }
    
    internal abstract ActionBaseSerializationRecord ToSerializationRecord();
}

[ProtoContract(Name = "Action")]
internal record ActionBaseSerializationRecord : MapComponentSerializationRecord
{
    public ActionBaseSerializationRecord()
    {
    }
    
    public ActionBaseSerializationRecord(string Id,
        string Type,
        string? Title,
        string? ClassName,
        bool? Active,
        bool? Disabled,
        bool? Visible,
        string? ActionId)
    {
        this.Id = Id;
        this.Type = Type;
        this.Title = Title;
        this.ClassName = ClassName;
        this.Active = Active;
        this.Disabled = Disabled;
        this.Visible = Visible;
        this.ActionId = ActionId;
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Title { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? ClassName { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public bool? Active { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public bool? Disabled { get; init; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public bool? Visible { get; init; }
    
    [ProtoMember(7)]
    public string? Id { get; init; }
    
    [ProtoMember(8)]
    public string? Image { get; init; }

    [ProtoMember(9)]
    public bool? Value { get; init; }
    
    [ProtoMember(10)]
    public string? ActionId { get; init; }

    public ActionBase FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guidId))
        {
            id = guidId;
        }
        
        return Type switch
        {
            "button" => new ActionButton(Title, Image, ActionId, null, ClassName, Active, Disabled, Visible)
            {
                Id = id
            },
            "toggle" => new ActionToggle(Title, ActionId, null, Value, Active, Disabled, Visible)
            {
                Id = id
            },
            _ => throw new NotSupportedException()
        };
    }
}

internal class ActionBaseConverter : JsonConverter<ActionBase>
{
    public override ActionBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "button":
                    return JsonSerializer.Deserialize<ActionButton>(ref cloneReader, newOptions);
                case "toggle":
                    return JsonSerializer.Deserialize<ActionToggle>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, ActionBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(object), options);
    }
}