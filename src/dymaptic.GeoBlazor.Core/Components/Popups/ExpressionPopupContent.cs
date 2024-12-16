namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     An ExpressionContent element allows you to define a popup content element with an Arcade expression. The expression
///     must evaluate to a dictionary representing a TextContent, FieldsContent, or a MediaContent popup element as defined
///     in the Popup Element web map specification.
///     Expressions defining popup content typically use the attributes property of an element to reference values
///     calculated within the expression in a table or a chart.
///     This content element is designed for advanced scenarios where content in charts, tables, or rich text elements is
///     based on logical conditions. For example, if data in one or more fields is empty, you can use this element to
///     dynamically create a table consisting only of fields containing valid data values. You can also use this element to
///     create charts or other content types consisting of aggregated data values. This can be especially useful in cluster
///     popups.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ExpressionContent.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ExpressionPopupContent : PopupContent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ExpressionPopupContent()
    {
    }

    /// <summary>
    ///     Constructor for creating a ExpressionPopupContent in code.
    /// </summary>
    /// <param name="expressionInfo">
    ///     Contains the Arcade expression used to create a popup content element. See the ElementExpressionInfo documentation
    /// </param>
    public ExpressionPopupContent(ElementExpressionInfo? expressionInfo)
    {
#pragma warning disable BL0005
        ExpressionInfo = expressionInfo;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string Type => "expression";

    /// <summary>
    ///     Contains the Arcade expression used to create a popup content element. See the ElementExpressionInfo documentation
    ///     for details and examples for how to create these expressions.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ElementExpressionInfo? ExpressionInfo { get; set; }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type) { ExpressionInfo = ExpressionInfo };
    }
}

/// <summary>
///     Defines an Arcade expression used to create an ExpressionContent element in a PopupTemplate. The expression must
///     evaluate to a dictionary, representing a TextContent, FieldsContent, or MediaContent popup element as defined in
///     the Popup Element web map specification.
///     This expression may access data values from the feature, its layer, or other layers in the map or datastore with
///     the $feature, $layer, $map, and $datastore profile variables. See the Popup Element Arcade Profile specification
///     for more information and examples of valid return dictionaries.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[ProtoContract]
public record ElementExpressionInfo
{
    /// <summary>
    ///     The Arcade expression evaluating to a dictionary. The dictionary must represent either a TextContent,
    ///     FieldsContent, or a MediaContent popup content element as defined in the Popup Element web map specification.
    ///     This expression may access data values from the feature, its layer, or other layers in the map or datastore with
    ///     the $feature, $layer, $map, and $datastore profile variables. See the Popup Element Arcade Profile specification
    ///     for more information and examples of valid return dictionaries.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Expression { get; set; }

    /// <summary>
    ///     The return type of the expression. Content element expressions always return dictionaries.
    ///     For ElementExpressionInfo the returnType is always "dictionary".
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? ReturnType { get; set; }

    /// <summary>
    ///     The title used to describe the popup element returned by the expression.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Title { get; set; }
}