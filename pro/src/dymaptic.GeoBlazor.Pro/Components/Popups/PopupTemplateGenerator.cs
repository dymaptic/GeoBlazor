namespace dymaptic.GeoBlazor.Pro.Components.Popups;

[CodeGenerationIgnore]
public partial class PopupTemplateGenerator : ProLogicComponent
{
    /// <summary>
    ///     Constructor for use by Dependency Injection. Use <see cref = "DependencyExtension.AddGeoBlazorPro"/> in your startup code.
    /// </summary>
    public PopupTemplateGenerator(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, IAppValidator appValidator, IJSRuntime jsRuntime) : base(authenticationManager, jsModuleManager, appValidator, jsRuntime)
    {
    }

    /// <summary>
    ///     Returns one or more suggested popupTemplates for a given layer based on its renderer. This method is useful in apps where a layer's renderer can be modified by the user (or some other process) and the popup template is expected to display values related to the renderer. Popup templates will not be generated for layers with renderers that don't refer to a data value (i.e. SimpleRenderer with no visual variables).
    /// </summary>
    /// <param name="layer">
    ///     The layer to which the suggested popup templates can be applied, or the point layer that is or will be clustered.
    /// </param>
    /// <param name="renderer">
    ///     Specify the renderer to be used on the layer (when featureReduction is enabled for clustering) if it will be different than the renderer already set on the layer.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<PopupTemplateResults> GetTemplates(Layer layer, Renderer? renderer = null)
    {
        return await InvokeAsync<PopupTemplateResults>("getTemplates", new { layer, renderer });
    }

    /// <summary>
    ///     Returns one or more suggested default popupTemplates for a given layer's FeatureReductionCluster configuration. The cluster popup will contain information describing features in the cluster, including the number of features in the cluster and summary statistics based on fields and expressions used in the layer's renderer.
    /// </summary>
    /// <param name="layer">
    ///     The layer to which the suggested popup templates can be applied, or the point layer that is or will be clustered.
    /// </param>
    /// <param name="renderer">
    ///     Specify the renderer to be used on the layer (when featureReduction is enabled for clustering) if it will be different than the renderer already set on the layer.
    /// </param>
    public async Task<PopupTemplateResults> GetClusterTemplates(Layer layer, Renderer? renderer = null)
    {
        return await InvokeAsync<PopupTemplateResults>("getClusterTemplates", new { layer, renderer });
    }

    /// <inheritdoc/>
    protected override string ComponentName => nameof(PopupTemplateGenerator);
    /// <inheritdoc/>
    protected override string Library => "Pro";
}