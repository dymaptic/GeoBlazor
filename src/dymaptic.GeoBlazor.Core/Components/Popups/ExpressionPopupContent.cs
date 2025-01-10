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
    [ActivatorUtilitiesConstructor]
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
    public override PopupContentType Type => PopupContentType.Expression;

    /// <summary>
    ///     Contains the Arcade expression used to create a popup content element. See the ElementExpressionInfo documentation
    ///     for details and examples for how to create these expressions.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ElementExpressionInfo? ExpressionInfo { get; set; }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type.ToString().ToKebabCase())
        {
            ExpressionInfo = ExpressionInfo
        };
    }
}