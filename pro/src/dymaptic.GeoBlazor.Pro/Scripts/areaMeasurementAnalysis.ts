
export async function buildJsAreaMeasurementAnalysis(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurementAnalysisGenerated } = await import('./areaMeasurementAnalysis.gb');
    return await buildJsAreaMeasurementAnalysisGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurementAnalysis(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAreaMeasurementAnalysisGenerated } = await import('./areaMeasurementAnalysis.gb');
    return await buildDotNetAreaMeasurementAnalysisGenerated(jsObject, layerId, viewId);
}
