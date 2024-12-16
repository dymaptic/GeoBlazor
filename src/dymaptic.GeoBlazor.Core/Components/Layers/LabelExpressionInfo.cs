namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     If working with a MapImageLayer that supports Arcade, you can also use labelExpressionInfo. To determine this,
///     check the supportsArcadeExpressionForLabeling property. If true, then labelExpression or labelExpressionInfo can be
///     used. If false, then only labelExpression can be used.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#labelExpressionInfo">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     MapImageLayer not yet implemented in GeoBlazor
/// </remarks>
public class LabelExpressionInfo : MapComponent
{
    /// <summary>
    ///     An Arcade expression following the specification defined by the Arcade Labeling Profile. Expressions in labels may
    ///     reference field values using the $feature global variable and must return a string.
    /// </summary>
    [Parameter]
    public string Expression { get; set; } = default!;
}