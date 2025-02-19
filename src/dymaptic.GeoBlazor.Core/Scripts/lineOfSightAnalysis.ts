
export async function buildJsLineOfSightAnalysis(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineOfSightAnalysisGenerated } = await import('./lineOfSightAnalysis.gb');
    return await buildJsLineOfSightAnalysisGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineOfSightAnalysis(jsObject: any): Promise<any> {
    let { buildDotNetLineOfSightAnalysisGenerated } = await import('./lineOfSightAnalysis.gb');
    return await buildDotNetLineOfSightAnalysisGenerated(jsObject);
}
