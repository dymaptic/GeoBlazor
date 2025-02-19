export async function buildJsPieChartCreateRendererForClusteringParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartCreateRendererForClusteringParamsGenerated } = await import('./pieChartCreateRendererForClusteringParams.gb');
    return await buildJsPieChartCreateRendererForClusteringParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPieChartCreateRendererForClusteringParams(jsObject: any): Promise<any> {
    let { buildDotNetPieChartCreateRendererForClusteringParamsGenerated } = await import('./pieChartCreateRendererForClusteringParams.gb');
    return await buildDotNetPieChartCreateRendererForClusteringParamsGenerated(jsObject);
}
