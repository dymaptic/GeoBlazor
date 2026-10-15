
export async function buildJsDimensionAnalysis(dotNetObject: any): Promise<any> {
    let { buildJsDimensionAnalysisGenerated } = await import('./dimensionAnalysis.gb');
    return await buildJsDimensionAnalysisGenerated(dotNetObject,);
}     

export async function buildDotNetDimensionAnalysis(jsObject: any): Promise<any> {
    let { buildDotNetDimensionAnalysisGenerated } = await import('./dimensionAnalysis.gb');
    return await buildDotNetDimensionAnalysisGenerated(jsObject);
}
