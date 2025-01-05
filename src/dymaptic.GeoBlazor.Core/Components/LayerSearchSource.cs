namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     The following properties define a Layer-based source whose features may be searched by a Search widget instance.
///     For string field searches, there is no leading wildcard. This effectively makes exactMatch true, which will remove unnecessary search results and suggestions.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-LayerSearchSource.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     Layers created from client-side graphics are not supported.
/// </remarks>
public class LayerSearchSource : SearchSource
{
    /// <inheritdoc/>
    public override string Type => "layer";

    /// <summary>
    ///     The results are displayed using this field. Defaults to the layer's displayField or the first string field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayField { get; set; }

    /// <summary>
    ///     Indicates to only return results that match the search value exactly. This property only applies to string field searches. exactMatch is always true when searching fields of type number. Default Value is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ExactMatch { get; set; }

    /// <summary>
    ///     The Id for the layer queried in the search. This is required. The layer can be a map/feature service feature layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer, GeoJSONLayer, CSVLayer or OGCFeatureLayer. See the SceneLayer Guide page on how to publish SceneLayers with associated feature layers.
    /// </summary>
    /// <remarks>
    ///     You may either specify a LayerId for an existing map layer, or nest a new <see cref = "FeatureLayer"/> inside this Search Source.
    ///     Feature layers created from client-side graphics are not supported.
    /// </remarks>
    [Parameter]
    [RequiredProperty(nameof(Layer))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? LayerId { get; set; }

    /// <summary>
    ///     One or more field names used to order the query results. Specfiy ASC (ascending) or DESC (descending) after the field name to control the order. The default order is ASC.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OrderByFields { get; set; }

    /// <summary>
    ///     An array of string values representing the names of fields in the feature layer to search.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? SearchFields { get; set; }

    /// <summary>
    ///     A template string used to display multiple fields in a defined order when suggestions are displayed. This takes precedence over displayField. Field names in the template must have the following format: {FieldName}. An example suggestionTemplate could look something like: Name: {OWNER}, Parcel: {PARCEL_ID}.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SuggestionTemplate { get; set; }

    /// <summary>
    ///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LayerSearchSourceFilter? Filter { get; set; }

    /// <summary>
    ///     The layer queried in the search. This is required. The layer can be a map/feature service feature layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer, GeoJSONLayer, CSVLayer or OGCFeatureLayer. See the SceneLayer Guide page on how to publish SceneLayers with associated feature layers.
    /// </summary>
    /// <remarks>
    ///     You may either specify a LayerId for an existing map layer, or nest a new <see cref = "FeatureLayer"/> inside this Search Source.
    ///     Feature layers created from client-side graphics are not supported.
    /// </remarks>
    [RequiredProperty(nameof(LayerId))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Layer? Layer { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerSearchSourceFilter filter:
                if (!filter.Equals(Filter))
                {
                    Filter = filter;
                }

                break;
            case Layer layer:
                if (!layer.Equals(Layer))
                {
                    Layer = layer;
                }

                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerSearchSourceFilter:
                Filter = null;
                break;
            case Layer _:
                Layer = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    internal override void ValidateRequiredChildren()
    {
        Filter?.ValidateRequiredChildren();
        Layer?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}



