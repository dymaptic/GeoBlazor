namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///     Helper class for generating default labels to be set on a layer's binning or cluster configuration.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-labels-bins.html">Bins: ArcGIS Maps SDK for JavaScript</a>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-labels-clusters.html">Clusters: ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LabelGenerator: ProLogicComponent
{
    /// <summary>
    ///     Constructor for use by Dependency Injection. Use <see cref="DependencyExtension.AddGeoBlazorPro"/> in your startup code.
    /// </summary>
    public LabelGenerator(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, 
        IAppValidator appValidator, IJSRuntime jsRuntime) : 
        base(authenticationManager, jsModuleManager, appValidator, jsRuntime)
    {
    }
    
    /// <summary>
    ///     Generates default labelingInfo schemes to be set on a FeatureLayer's featureReduction configuration. Returns one or more suggested LabelClasses for a given layer based on its renderer. It also returns a suggested clusterMinSize to ensure labels fit inside clusters.
    ///     If a renderer has a non-scale dependent SizeVariable, then the average value of the field or expression used to determine the cluster size will be suggested as the default label value. In all other scenarios, the suggested label will display the cluster count in the center of the label.
    /// </summary>
    /// <param name="layer">
    ///     The point layer that has or will have clustering enabled.
    /// </param>
    /// <param name="viewId">
    ///      The Id for the view where the input layer will be rendered.
    /// </param>
    /// <param name="field">
    ///     The name of the AggregateField to use in the primary label scheme. If not specified, then the label will be based on the data used to vary cluster size.
    /// </param>
    /// <param name="renderer">
    ///     The renderer to set on the input layer when clustering is enabled. Specify this parameter if the layer's renderer does not match the renderer that will be used when clustering is enabled. This cannot be a HeatmapRenderer.
    /// </param>
    public async Task<LabelSchemes> GetClusterLabelSchemes(Layer layer, Guid viewId, string? field = null, 
        Renderer? renderer = null)
    {
        return await InvokeAsync<LabelSchemes>("getClusterLabelSchemes", new { layer, viewId, field, renderer});
    }
    
    /// <summary>
    ///     The renderer to set on the input layer when clustering is enabled. Specify this parameter if the layer's renderer does not match the renderer that will be used when clustering is enabled. This cannot be a HeatmapRenderer.
    /// </summary>
    
    /// <param name="layer">
    ///     The view where the input layer will be rendered.
    /// </param>
    /// <param name="field">
    ///     The name of the AggregateField to use in the primary label scheme. If not specified, then the label will be based on the aggregate count field.
    /// </param>
    /// <param name="renderer">
    ///     The renderer to set on layer.featureReduction.renderer when binning is enabled.
    /// </param>
    public async Task<LabelSchemes> GetBinLabelSchemes(Layer layer, string? field = null, Renderer? renderer = null)
    {
        return await InvokeAsync<LabelSchemes>("getBinLabelSchemes", new { layer, field, renderer });
    }

    /// <inheritdoc />
    protected override string ComponentName => nameof(LabelGenerator);
    
    /// <inheritdoc />
    protected override string Library => "Pro";
}

/// <summary>
///     The return object of the <see cref="LabelGenerator.GetClusterLabelSchemes"/> or <see cref="LabelGenerator.GetBinLabelSchemes"/> methods.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-labels-clusters.html#Schemes">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="PrimaryScheme">
///     Includes the primary labeling scheme suggested for the input layer's clusters.
/// </param>
/// <param name="SecondarySchemes">
///     Includes secondary labeling schemes suggested for the input layer's clusters.
/// </param>
public record LabelSchemes(LabelScheme PrimaryScheme, IReadOnlyCollection<LabelScheme> SecondarySchemes);

/// <summary>
///     Contains a suggested labelingInfo to be set on the layer's featureReduction.labelingInfo.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-labels-clusters.html#Scheme">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Name">
///     The name of the generated cluster labeling scheme. This can be used in the UI of web map authoring apps.
/// </param>
/// <param name="FieldName">
///     The name of the aggregate field the labeling scheme is based on. This can be used in the UI of web map authoring apps.
/// </param>
/// <param name="LabelingInfo">
///     An array of LabelClass objects to set on the layer's featureReduction.labelingInfo property.
/// </param>
/// <param name="ClusterMinSize">
///     The suggested featureReduction.clusterMinSize required to fit labels within clusters.
/// </param>
public record LabelScheme(string Name, string FieldName, IReadOnlyCollection<Label> LabelingInfo, double? ClusterMinSize);