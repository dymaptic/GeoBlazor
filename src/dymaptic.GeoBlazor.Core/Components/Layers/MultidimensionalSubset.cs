using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Renderers;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A subset of multidimensional raster data created by slicing the data along defined variables and dimensions. Only dimensional slices that meet the multidimensionalSubset requirements will be available on a multidimensional ImageryLayer or ImageryTileLayer when the multiDimensionalSubset property is set on the layer. For example, if you have an ImageryLayer that contains 30 years of monthly precipitation data, and you only want to expose data for each January to see how precipitation has changed for that month, you can set the multiDimensionalSubset on the imagery layer.
///     When the multiDimensionalSubset is defined on a layer, the multidimensionalDefinition property of the ImageryTileLayer or the mosaicRule.multidimensionalDefinition of the ImageryLayer must be within the defined multidimensionalSubset, otherwise nothing will be displayed on the map or available for analysis.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-MultidimensionalSubset.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class MultidimensionalSubset : MapComponent
{
    /// <summary>
    ///     The spatial area of interest as an Extent. The area of interest can only be set on an ImageryLayer. Only the imagery within the area of interest will be available when set.
    ///     Use either this or <see cref="PolygonOfInterest"/>.
    /// </summary>
    /// <remarks>
    ///     This property will not be honored on an ImageryTileLayer.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? ExtentOfInterest { get; set; }
    
    /// <summary>
    ///     The spatial area of interest as a Polygon. The area of interest can only be set on an ImageryLayer. Only the imagery within the area of interest will be available when set.
    ///     Use either this or <see cref="ExtentOfInterest"/>.
    /// </summary>
    /// <remarks>
    ///     This property will not be honored on an ImageryTileLayer.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Polygon? PolygonOfInterest { get; set; }

    /// <summary>
    ///     The variable and dimension subset definitions to set the layer. Only the dimensional definitions defined here will be available on the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
#pragma warning disable BL0007
    public IReadOnlyList<DimensionalDefinition> SubsetDefinitions
#pragma warning restore BL0007
    {
        get => _subsetDefinitions;
        set => _subsetDefinitions = new List<DimensionalDefinition>(value);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DimensionalDefinition dimensionalDefinition:
                _subsetDefinitions.Add(dimensionalDefinition);
                
                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case DimensionalDefinition dimensionalDefinition:
                _subsetDefinitions.Remove(dimensionalDefinition);
                
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        foreach (DimensionalDefinition definition in _subsetDefinitions)
        {
            definition.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }

    private List<DimensionalDefinition> _subsetDefinitions = new();
}