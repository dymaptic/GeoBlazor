
export async function buildJsISliceAnalysisExcludedLayers(dotNetObject: any): Promise<any> {
    let { buildJsISliceAnalysisExcludedLayersGenerated } = await import('./iSliceAnalysisExcludedLayers.gb');
    return await buildJsISliceAnalysisExcludedLayersGenerated(dotNetObject);
}     

export async function buildDotNetISliceAnalysisExcludedLayers(jsObject: any): Promise<any> {
    let { buildDotNetISliceAnalysisExcludedLayersGenerated } = await import('./iSliceAnalysisExcludedLayers.gb');
    return await buildDotNetISliceAnalysisExcludedLayersGenerated(jsObject);
}
