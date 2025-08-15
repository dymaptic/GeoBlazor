
export async function buildJsISliceAnalysisExcludedLayers(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsISliceAnalysisExcludedLayersGenerated } = await import('./iSliceAnalysisExcludedLayers.gb');
    return await buildJsISliceAnalysisExcludedLayersGenerated(dotNetObject, viewId);
}     

export async function buildDotNetISliceAnalysisExcludedLayers(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetISliceAnalysisExcludedLayersGenerated } = await import('./iSliceAnalysisExcludedLayers.gb');
    return await buildDotNetISliceAnalysisExcludedLayersGenerated(jsObject, viewId);
}
