export async function buildJsDimensionAnalysis(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDimensionAnalysisGenerated} = await import('./dimensionAnalysis.gb');
    return await buildJsDimensionAnalysisGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDimensionAnalysis(jsObject: any): Promise<any> {
    let {buildDotNetDimensionAnalysisGenerated} = await import('./dimensionAnalysis.gb');
    return await buildDotNetDimensionAnalysisGenerated(jsObject);
}
