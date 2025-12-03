
export async function buildJsSliceAnalysis(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSliceAnalysisGenerated } = await import('./sliceAnalysis.gb');
    return await buildJsSliceAnalysisGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSliceAnalysis(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSliceAnalysisGenerated } = await import('./sliceAnalysis.gb');
    return await buildDotNetSliceAnalysisGenerated(jsObject, viewId);
}
