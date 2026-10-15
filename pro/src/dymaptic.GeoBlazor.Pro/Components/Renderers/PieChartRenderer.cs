using dymaptic.GeoBlazor.Pro.Options;


namespace dymaptic.GeoBlazor.Pro.Components.Renderers;

public partial class PieChartRenderer: Renderer
{
    /// <inheritdoc />
    public override RendererType Type => RendererType.PieChart;

    /// <summary>
    ///     The color used to visualize features whose attributes all have null or empty values. By default, this is a transparent color, so no chart displays. You should set this value if you would like to show areas with features, but no data associated with it.
    ///     Default Value:new MapColor(0, 0, 0, 0)
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? DefaultColor { get; set; }
    
    /// <summary>
    ///     Describes the defaultColor in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefaultLabel { get; set; }
    
    /// <summary>
    ///     Use this property to create a donut chart. Defines the size of the hole to cut from the center of the chart as a percentage of the entire pie chart. Accepted values are between 0 and 1. For example, a hole percentage of 0 will render a full pie chart. A ratio of 0.5 will remove 50% of the center of the pie, creating a donut.
    ///     Default Value:0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? HolePercentage { get; set; }
    
    /// <summary>
    ///     Defines the size of each pie chart in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    ///     Default Value:12
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Size { get; set; }


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case AttributeColorInfo colorInfo:
                Attributes ??= [];
                Attributes = [..Attributes, colorInfo];

                break;
            case SimpleFillSymbol fillSymbol:
                if (!fillSymbol.Equals(BackgroundFillSymbol))
                {
                    BackgroundFillSymbol = fillSymbol;
                }

                break;

            case SizeVariable sizeVariable:
                VisualVariables ??= [];
                VisualVariables = [..VisualVariables, sizeVariable];

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
            case AttributeColorInfo colorInfo:
                Attributes = Attributes?.Except([colorInfo]).ToList();

                break;

            case SimpleFillSymbol fillSymbol:
                if (fillSymbol.Equals(BackgroundFillSymbol))
                {
                    BackgroundFillSymbol = null;
                }

                break;

            case SizeVariable sizeVariable:
                VisualVariables = VisualVariables?.Except([sizeVariable]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}