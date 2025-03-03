
export async function buildJsAreaMeasurementAnalysisResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurementAnalysisResultGenerated } = await import('./areaMeasurementAnalysisResult.gb');
    return await buildJsAreaMeasurementAnalysisResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurementAnalysisResult(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurementAnalysisResultGenerated } = await import('./areaMeasurementAnalysisResult.gb');
    return await buildDotNetAreaMeasurementAnalysisResultGenerated(jsObject);
}
