
export async function buildJsAnalysis(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAnalysisGenerated } = await import('./analysis.gb');
    return await buildJsAnalysisGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAnalysis(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetAnalysisGenerated } = await import('./analysis.gb');
    return await buildDotNetAnalysisGenerated(jsObject, viewId);
}
