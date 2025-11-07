namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(ActionBaseConverter))]
[CodeGenerationIgnore]
public abstract partial class ActionBase : MapComponent, IProtobufSerializable<ActionBaseSerializationRecord>
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
    
    public abstract ActionBaseSerializationRecord ToProtobuf();
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