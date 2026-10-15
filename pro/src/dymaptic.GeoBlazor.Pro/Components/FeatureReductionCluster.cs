namespace dymaptic.GeoBlazor.Pro.Components;

public partial class FeatureReductionCluster : FeatureReduction
{


    /// <inheritdoc/>
    public override string Type => "cluster";

    /// <summary>
    ///     Defines the symbol size of the largest cluster in points (or pixels if specified). Adjusting clusterMaxSize generally should be considered if the clusterRadius is modified.
    ///     For example, if you prefer cluster icons to not overlap, then the clusterMaxSize should be substantially smaller than the clusterRadius.
    ///     If a custom renderer is defined for cluster, and that renderer contains a esri/renderers/visualVaribles/SizeVariable, then this property is ignored and cluster sizes are determined using the renderer's size variable.
    ///     Default Value:37.5
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? ClusterMaxSize { get; set; }

    /// <summary>
    ///     Defines the symbol size of the smallest cluster in points (or pixels if specified). If labeling clusters with a count or some other information in the center of the cluster, then having a clusterMinSize larger than the default is generally preferred.
    ///     Keep in mind that this size may be smaller than the symbol size of individual non-clustered features in the layer. In that scenario, you should either reduce the size of the symbol(s) in the layer's renderer or increase the clusterMinSize to be larger than the size of individual points to avoid confusion for the end user. This is most likely to happen when cluster size represents feature count.
    ///     If a custom renderer is defined for cluster, and that renderer contains a esri/renderers/visualVaribles/SizeVariable, then this property is ignored and cluster sizes are determined using the renderer's size variable.
    ///     Default Value:9
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? ClusterMinSize { get; set; }

    /// <summary>
    ///     Defines the radius in points (or pixels if specified) of the area in which multiple points will be grouped and visualized as a single cluster. Adjusting clusterRadius generally should be considered if the clusterMaxSize is modified.
    ///     For example, if you prefer cluster graphics to not overlap, then the clusterRadius should be substantially larger than the clusterMaxSize.
    ///     Default Value:60
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? ClusterRadius { get; set; }

    /// <summary>
    ///     Indicates whether to display labels for the clusters. If true, labels will appear as defined in the labelingInfo property.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelsVisible { get; set; }

    /// <summary>
    ///     Defines the maximum view scale at which clustering is enabled. If the user zooms in beyond the scale specified here, clustering will be disabled and only individual features will be displayed in the view. Once the user zooms out past this scale, clustering will be re-enabled. A value of 0 means clustering is always enabled, and therefore clusters may be visible at any view scale.
    ///     Default Value:0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     Indicates whether to display the cluster popup. If true, popups will open when the user clicks or taps a cluster. If false, the popup as defined in the popupTemplate will be persisted, but won't be displayed on click/tap.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }


    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        Layer? layer = Parent as Layer;
        switch (child)
        {
            case AggregateField aggregateField:
                if (_fields.Add(aggregateField) && layer is not null && MapRendered)
                {
                    await layer.UpdateLayer();
                }

                break;
            case Label label:
                if (_labelingInfo.Add(label) && layer is not null && MapRendered)
                {
                    await layer.UpdateLayer();
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
            case AggregateField aggregateField:
                _fields.Remove(aggregateField);
                break;
            case Label label:
                _labelingInfo.Remove(label);
                break;

            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }


    private HashSet<AggregateField> _fields = new();
    private HashSet<Label> _labelingInfo = new();
}


