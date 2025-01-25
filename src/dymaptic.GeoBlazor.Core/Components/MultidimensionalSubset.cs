namespace dymaptic.GeoBlazor.Core.Components;

public partial class MultidimensionalSubset : MapComponent
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


    private List<DimensionalDefinition> _subsetDefinitions = new();
}