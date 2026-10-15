namespace dymaptic.GeoBlazor.Pro.Components;

public partial class FeatureReductionBinning : FeatureReduction
{


    /// <inheritdoc/>
    public override string Type => "binning";

    /// <summary>
    ///     The fixed geohash level used to create bins. Currently, bin sizes do not dynamically change as the user zooms in and out of the map. Larger numbers will create smaller bins. Levels range from 1 - 9. See <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureReductionBinning.html#fixedBinLevel">fixedBinLevel</a> to see which bin level to use depending on the approximate view scale.
    ///     Default Value: 3
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FixedBinLevel { get; set; }

    /// <summary>
    ///     Indicates whether to display labels for the bins. If true, labels will appear as defined in the <see cref = "LabelingInfo"/> property.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelsVisible { get; set; }

    /// <summary>
    ///     Defines the maximum view scale at which binning is enabled. If the user zooms in beyond the scale specified here, binning will be disabled and only individual features will be displayed in the view. Once the user zooms out past this scale, binning will be re-enabled. A value of 0 means binning is always enabled, and therefore binning will be visible at all view scales.
    ///     Default Value:0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     Indicates whether to display a popup when a user clicks or touches a bin. If false, the popup as defined in the popupTemplate will be persisted, but won't be displayed on click/tap.
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


