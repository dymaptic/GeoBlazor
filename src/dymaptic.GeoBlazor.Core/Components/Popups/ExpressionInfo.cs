using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using ProtoBuf;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     The ExpressionInfo class references Arcade expressions following the specification defined by the Arcade Popup
///     Profile. Expressions must return a string or a number and may access data values from the feature, its layer, or
///     other layers in the map or datastore with the $feature, $layer, $map, and $datastore profile variables.
///     Expression names are referenced in a layer's PopupTemplate and execute once a layer's popup is opened. The values
///     display within the view's popup as if they are field values. They can be displayed in a table using the FieldInfo
///     of the popupTemplate's content or referenced within a simple string.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ExpressionInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ExpressionInfo : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public ExpressionInfo()
    {
    }

    /// <summary>
    ///     Constructor for creating a new ExpressionInfo in code with parameters
    /// </summary>
    /// <param name="expression">
    ///     An Arcade expression following the specification defined by the Arcade Popup Profile. Expressions must return a
    /// </param>
    /// <param name="name">
    ///     The name of the expression. This is used to reference the value of the given expression in the popupTemplate's
    /// </param>
    /// <param name="title">
    ///     The title used to describe the value returned by the expression in the popup. This will display if the value is
    /// </param>
    /// <param name="returnType">
    ///     Indicates the return type of the Arcade expression.
    /// </param>
    public ExpressionInfo(string? expression, string? name, string? title, ReturnType? returnType)
    {
#pragma warning disable BL0005
        Expression = expression;
        Name = name;
        Title = title;
        ReturnType = returnType;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     An Arcade expression following the specification defined by the Arcade Popup Profile. Expressions must return a
    ///     string or a number and may access data values from the feature, its layer, or other layers in the map or datastore
    ///     with the $feature, $layer, $map, and $datastore profile variables.
    /// </summary>
    [Parameter]
    public string? Expression { get; set; }

    /// <summary>
    ///     The name of the expression. This is used to reference the value of the given expression in the popupTemplate's
    ///     content property by wrapping it in curly braces and prefacing it with expression/ (e.g.
    ///     {expression/expressionName}).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    /// <summary>
    ///     The title used to describe the value returned by the expression in the popup. This will display if the value is
    ///     referenced in a FieldInfo table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Indicates the return type of the Arcade expression.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReturnType? ReturnType { get; set; }
    
    internal ExpressionInfoSerializationRecord ToSerializationRecord()
    {
        return new ExpressionInfoSerializationRecord(Expression, Name, Title, ReturnType);
    }
}

[ProtoContract(Name = "ExpressionInfo")]
internal record ExpressionInfoSerializationRecord : MapComponentSerializationRecord
{
    public ExpressionInfoSerializationRecord()
    {
    }
    
    public ExpressionInfoSerializationRecord(string? Expression,
        string? Name,
        string? Title,
        ReturnType? ReturnType)
    {
        this.Expression = Expression;
        this.Name = Name;
        this.Title = Title;
        this.ReturnType = ReturnType;
    }

    public ExpressionInfo FromSerializationRecord()
    {
        return new ExpressionInfo();
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Expression { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Name { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Title { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public ReturnType? ReturnType { get; init; }
}

/// <summary>
///     Indicates the return type of the Arcade expression.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ReturnType>))]
public enum ReturnType
{
#pragma warning disable CS1591
    String,
    Number
#pragma warning restore CS1591
}