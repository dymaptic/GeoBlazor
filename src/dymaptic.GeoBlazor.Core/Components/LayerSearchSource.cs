namespace dymaptic.GeoBlazor.Core.Components;

public partial class LayerSearchSource : SearchSource
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
    ///     A template string used to display multiple fields in a defined order when suggestions are displayed. This takes precedence over displayField. Field names in the template must have the following format: {FieldName}. An example suggestionTemplate could look something like: Name: {OWNER}, Parcel: {PARCEL_ID}.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SuggestionTemplate { get; set; }


    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {

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

        Layer?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}



