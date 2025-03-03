
export async function buildJsDirectLineMeasurementAnalysisResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectLineMeasurementAnalysisResultGenerated } = await import('./directLineMeasurementAnalysisResult.gb');
    return await buildJsDirectLineMeasurementAnalysisResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectLineMeasurementAnalysisResult(jsObject: any): Promise<any> {
    let { buildDotNetDirectLineMeasurementAnalysisResultGenerated } = await import('./directLineMeasurementAnalysisResult.gb');
    return await buildDotNetDirectLineMeasurementAnalysisResultGenerated(jsObject);
}
