namespace dymaptic.GeoBlazor.Core.Components;

public partial class AggregateField : MapComponent
{


    /// <summary>
    ///     The display name that describes the aggregate field in the Legend, Popup, and other UI elements.
    ///     Default Value: null
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Alias { get; set; }

    /// <summary>
    ///     Indicates whether the field was created internally by the JS API's rendering engine for default FeatureReductionCluster visualizations. You should avoid setting or changing this value. If true, then all other properties of the AggregateField are read-only.
    ///     Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsAutoGenerated { get; set; }

    /// <summary>
    ///     The name of the aggregate field. This should describe the layer's field and aggregation method used. For example, if creating a field that contains the total population for a set of features with a population field, then you could name this field total_population or popuplation_sum. This field name must start with a letter, and may only contain alphanumeric characters and underscore.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }


    /// <summary>
    ///     The name of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#fields">layer field</a> to summarize with the given <see cref = "StatisticType"/>.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OnStatisticField { get; set; }

    /// <summary>
    ///     Defines the type of statistic used to aggregate data returned from <see cref = "OnStatisticField"/> or <see cref = "OnStatisticExpression"/>.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AggregateStatisticType? StatisticType { get; set; }
}

