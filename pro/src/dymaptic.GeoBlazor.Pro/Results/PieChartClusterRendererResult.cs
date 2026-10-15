namespace dymaptic.GeoBlazor.Pro.Results;

/// <summary>
///     The result object of the <see cref="PieChartGenerator.CreateRendererForClustering"/> method.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-renderers-pieChart.html#ClusterRendererResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Renderer">
///     The generated pie chart renderer to use for clustering. Set this on a renderer property of the FeatureReductionCluster instance to update its visualization.
/// </param>
/// <param name="Fields">
///     The aggregate fields used by the renderer. Set this on a fields property of the FeatureReductionCluster instance alongside the renderer to update the clustering visualization to pie charts.
/// </param>
public record PieChartClusterRendererResult(PieChartRenderer Renderer, IReadOnlyCollection<AggregateField> Fields);