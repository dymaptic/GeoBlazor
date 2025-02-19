export async function buildJsViewshedAnalysis(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewshedAnalysisGenerated } = await import('./viewshedAnalysis.gb');
    return await buildJsViewshedAnalysisGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetViewshedAnalysis(jsObject: any): Promise<any> {
    let { buildDotNetViewshedAnalysisGenerated } = await import('./viewshedAnalysis.gb');
    return await buildDotNetViewshedAnalysisGenerated(jsObject);
}
