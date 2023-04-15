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
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ExpressionInfo.html">
///         ArcGIS
///         API for JS
///     </a>
/// </summary>
public class ExpressionInfo : MapComponent, IEquatable<ExpressionInfo>
{
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
        return new(Expression, Name, Title, ReturnType);
    }

    /// <inheritdoc />
    public bool Equals(ExpressionInfo? other)
    {
        if (ReferenceEquals(null, other)) return false;

        return Expression == other.Expression && Name == other.Name && Title == other.Title && 
            ReturnType == other.ReturnType;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((ExpressionInfo)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Expression, Name, Title, ReturnType);
    }

    /// <summary>
    ///    Equality operator.
    /// </summary>
    public static bool operator ==(ExpressionInfo? left, ExpressionInfo? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///    Inequality operator.
    /// </summary>
    public static bool operator !=(ExpressionInfo? left, ExpressionInfo? right)
    {
        return !Equals(left, right);
    }
}

[ProtoContract(Name = "ExpressionInfo")]
internal record ExpressionInfoSerializationRecord(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [property: ProtoMember(1)]string? Expression, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [property: ProtoMember(2)]string? Name, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [property: ProtoMember(3)]string? Title,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [property: ProtoMember(4)]ReturnType? ReturnType) 
    : MapComponentSerializationRecord;

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