namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class FeatureTemplatesWidget: ProWidget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.FeatureTemplates;
    
    /// <summary>
    ///     An array of Ids for <see cref="FeatureLayer"/>s to display within the widget. The order in which these layers are set in the array dictates how they display within the widget.
    /// </summary>
    /// <remarks>
    ///     Use either `Layers` or `LayerIds`
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    [CodeGenerationIgnore]
    public IReadOnlyList<Guid>? LayerIds { get; set; }
    
    /// <summary>
    ///     An array of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">FeatureLayers</a> to display within the widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FeatureTemplates.html#layers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <remarks>
    ///     Use either `Layers` or `LayerIds`
    /// </remarks>
    [ArcGISProperty]
    [Parameter]
    [CodeGenerationIgnore]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<IFeatureTemplatesWidgetLayers>? Layers { get; set; }
}

/// <summary>
///     The event object that fires when a template item is selected.
/// </summary>
/// <param name="Item">
///     The selected template item.
/// </param>
/// <param name="Template">
///     The feature template associated with the template item.
/// </param>
public record FeatureTemplateSelectEvent(TemplateItem Item, FeatureTemplate Template);

