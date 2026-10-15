namespace dymaptic.GeoBlazor.Pro.Components;

public partial class PieChartGenerator : ProLogicComponent
{
    /// <summary>
    ///     Constructor for use by Dependency Injection. Use <see cref = "DependencyExtension.AddGeoBlazorPro"/> in your startup code.
    /// </summary>
    [CodeGenerationIgnore]
    public PieChartGenerator(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, IAppValidator appValidator, IJSRuntime jsRuntime) : base(authenticationManager, jsModuleManager, appValidator, jsRuntime)
    {
    }

    /// <summary>
    ///     Generates a PieChartRenderer based on a set of numeric fields.
    /// </summary>
    /// <param name = "layer">
    ///     The layer for which the visualization is generated.
    /// </param>
    /// <param name = "viewId">
    ///     The view instance in which the visualization will be rendered.
    /// </param>
    /// <param name = "attributes">
    ///     A set of complementary numeric fields/expressions used to create the charts. For example, if creating an election map, you would indicate the name of each field representing the candidate or political party where their total counts are stored.
    /// </param>
    /// <param name = "shape">
    ///     Default Value: "pie"
    ///     Determines whether to create a pie chart or a donut chart.
    /// </param>
    /// <param name = "includeSizeVariable">
    ///     Indicates whether to include data-driven size in the final renderer. If true, features will be assigned a sized based on the sum of all values in the attributes param. Features with small total counts will be sized with small charts and features with large total counts will be sized with large charts. Enabling this option is good for visualizing how influential a particular feature is compared to the dataset as a whole. It removes bias introduced by features with large geographic areas, but relatively small data values.
    /// </param>
    /// <param name = "outlineOptimizationEnabled">
    ///     Default Value: false
    ///     Only for polygon layers. Indicates whether the polygon's background fill symbol outline width should vary based on view scale.
    /// </param>
    /// <param name = "sizeOptimizationEnabled">
    ///     Default Value: false
    ///     Indicates whether chart sizes should vary based on view scale.
    /// </param>
    /// <param name = "legendOptions">
    ///     Provides options for modifying Legend properties describing the visualization.
    /// </param>
    /// <param name = "pieChartScheme">
    ///     In authoring apps, the user may select a pre-defined color scheme. Pass the scheme object to this property to avoid getting one based on the background of the view.
    /// </param>
    /// <param name = "forBinning">
    ///     Indicates whether the generated renderer is for a binning visualization. If true, then the input field(s) in this method should refer to aggregate fields defined in the featureReduction property of the layer.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<PieChartRendererResult> CreateRenderer(Layer layer, Guid viewId, IReadOnlyCollection<AttributeColorInfo> attributes, PieChartShape? shape, bool? includeSizeVariable, bool? outlineOptimizationEnabled, bool? sizeOptimizationEnabled, VisualVariableLegendOptions? legendOptions, PieChartScheme? pieChartScheme, bool? forBinning)
    {
        return await InvokeAsync<PieChartRendererResult>("createRenderer", new { layer, viewId, attributes, shape, includeSizeVariable, outlineOptimizationEnabled, sizeOptimizationEnabled, legendOptions, pieChartScheme, forBinning });
    }

    /// <summary>
    ///     Generates a PieChartRenderer to use for a FeatureReductionCluster visualization based off an input layer's UniqueValueRenderer or ClassBreaksRenderer. This method also generates aggregate fields that must be provided to the FeatureReductionCluster object to properly render.
    /// </summary>
    /// <param name = "layer">
    ///     The layer for which the visualization is generated. To use the output cluster renderer, you must first enable clustering on the layer.
    /// </param>
    /// <param name = "shape">
    ///     Default Value: "pie"
    ///     Determines whether to create a pie chart or a donut chart.
    /// </param>
    /// <param name = "defaultSymbolEnabled">
    ///     Default Value: true
    ///     Includes the defaultSymbol defined in the input layer's renderer in the output pie chart renderer.
    /// </param>
    /// <param name = "legendOptions">
    ///     Provides options for modifying Legend properties describing the visualization.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<PieChartClusterRendererResult> CreateRendererForClustering(Layer layer, PieChartShape? shape = null, bool? defaultSymbolEnabled = null, VisualVariableLegendOptions? legendOptions = null)
    {
        return await InvokeAsync<PieChartClusterRendererResult>("createRendererForClustering", new { layer, shape, defaultSymbolEnabled, legendOptions });
    }

    /// <inheritdoc/>
    protected override string ComponentName => nameof(PieChartGenerator);
    /// <inheritdoc/>
    protected override string Library => "Pro";
}


