namespace dymaptic.GeoBlazor.Core.Components.Popups;

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