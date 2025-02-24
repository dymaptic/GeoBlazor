namespace dymaptic.GeoBlazor.Core.Components;

public partial class LayerSearchSource : SearchSource
{
    /// <inheritdoc/>
    public override SearchSourceType Type => SearchSourceType.Layer;

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

    public override void ValidateRequiredChildren()
    {
        Layer?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}


