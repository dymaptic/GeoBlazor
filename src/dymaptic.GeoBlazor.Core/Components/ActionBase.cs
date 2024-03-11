using Microsoft.AspNetCore.Components;
using ProtoBuf;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Actions are customizable behavior which can be executed in certain widgets such as Popups, a BasemapLayerList, or a
///     LayerList.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(ActionBaseConverter))]
public abstract class ActionBase : MapComponent
{
    /// <summary>
    ///     The title of the action.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     The name of the ID assigned to this action.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public new string? Id { get; set; }

    /// <summary>
    ///     Set this property to true to display a spinner icon. You should do this if the action executes an async operation,
    ///     such as a query, that requires letting the end user know that a process is ongoing in the background. Set the
    ///     property back to false to communicate to the user that the process has finished.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Active { get; set; }

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
    [EditorRequired]
    [JsonIgnore]
    [RequiredProperty]
    public Func<Task>? CallbackFunction { get; set; }

    /// <summary>
    ///     Specifies the type of action. Choose between "button" or "toggle".
    /// </summary>
    public virtual string Type { get; } = default!;
    
    internal abstract ActionBaseSerializationRecord ToSerializationRecord();
}

[ProtoContract(Name = "Action")]
internal record ActionBaseSerializationRecord : MapComponentSerializationRecord
{
    public ActionBaseSerializationRecord()
    {
    }
    
    public ActionBaseSerializationRecord(string Type,
        string? Title,
        string? ClassName,
        bool? Active,
        bool? Disabled,
        bool? Visible,
        string? Id)
    {
        this.Type = Type;
        this.Title = Title;
        this.ClassName = ClassName;
        this.Active = Active;
        this.Disabled = Disabled;
        this.Visible = Visible;
        this.Id = Id;
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
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(7)]
    public string? Id { get; init; }
    
    [ProtoMember(8)]
    public string? Image { get; init; }

    [ProtoMember(9)]
    public bool? Value { get; init; }

    public ActionBase FromSerializationRecord()
    {
        return Type switch
        {
            "button" => new ActionButton(Title, Image, Id, null, ClassName, Active, Disabled, Visible),
            "toggle" => new ActionToggle(Title, Id, null, Value, Active, Disabled, Visible),
            _ => throw new NotSupportedException()
        };
    }
}

/// <summary>
///     A customizable button that performs a specific action(s) used in widgets such as the Popup, LayerList, and
///     BasemapLayerList.
/// </summary>
public class ActionButton : ActionBase
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ActionButton()
    {
    }

    /// <summary>
    ///    Constructor for use in code.
    /// </summary>
    /// <param name="title">
    ///     The title of the action.
    /// </param>
    /// <param name="image">
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image
    /// </param>
    /// <param name="id">
    ///     The name of the ID assigned to this action.
    /// </param>
    /// <param name="callbackFunction">
    ///     The action function to perform on click.
    /// </param>
    /// <param name="className">
    ///     This adds a CSS class to the ActionButton's node.
    /// </param>
    /// <param name="active">
    ///     Set this property to true to display a spinner icon.
    /// </param>
    /// <param name="disabled">
    ///     Indicates whether this action is disabled.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the action is visible.
    /// </param>
    public ActionButton(string? title = null, string? image = null, string? id = null,
        Func<Task>? callbackFunction = null, string? className = null, bool? active = null, bool? disabled = null,
        bool? visible = null)
    {
#pragma warning disable BL0005
        Title = title;
        Image = image;
        Id = id;
        CallbackFunction = callbackFunction;
        ClassName = className;
        Active = active;
        Disabled = disabled;
        Visible = visible;
#pragma warning restore BL0005
    }
    
    /// <inheritdoc />
    public override string Type => "button";

    /// <summary>
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image for
    ///     the node. It may be used in conjunction with the className property or by itself. If neither image nor className
    ///     are specified, a default icon will display
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }
    
    /// <summary>
    ///     This adds a CSS class to the ActionButton's node.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClassName { get; set; }

    internal override ActionBaseSerializationRecord ToSerializationRecord()
    {
        return new ActionBaseSerializationRecord(Type, Title, ClassName, Active, Disabled, Visible, Id)
        {
            Image = Image
        };
    }
}

/// <summary>
///     A customizable toggle used in the LayerList widget that performs a specific action(s) which can be toggled on/off.
/// </summary>
public class ActionToggle : ActionBase
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ActionToggle()
    {
    }

    /// <summary>
    ///    Constructor for use in code.
    /// </summary>
    /// <param name="title">
    ///     The title of the action.
    /// </param>
    /// <param name="id">
    ///     The name of the ID assigned to this action.
    /// </param>
    /// <param name="callbackFunction">
    ///     The action function to perform on click.
    /// </param>
    /// <param name="value">
    ///     Indicates the value of whether the action is toggled on/off.
    /// </param>
    /// <param name="active">
    ///     Set this property to true to display a spinner icon.
    /// </param>
    /// <param name="disabled">
    ///     Indicates whether this action is disabled.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the action is visible.
    /// </param>
    public ActionToggle(string? title = null, string? id = null, Func<Task>? callbackFunction = null,
        bool? value = null, bool? active = null, bool? disabled = null, bool? visible = null)
    {
#pragma warning disable BL0005
        Title = title;
        Id = id;
        CallbackFunction = callbackFunction;
        Value = value;
        Active = active;
        Disabled = disabled;
        Visible = visible;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string Type => "toggle";

    /// <summary>
    ///     Indicates the value of whether the action is toggled on/off.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Value { get; set; }

    internal override ActionBaseSerializationRecord ToSerializationRecord()
    {
        return new ActionBaseSerializationRecord(Type, Title, null, Active, Disabled, Visible, Id)
        {
            Value = Value
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