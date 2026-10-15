
export async function buildJsDirectLineMeasurementAnalysis(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectLineMeasurementAnalysisGenerated } = await import('./directLineMeasurementAnalysis.gb');
    return await buildJsDirectLineMeasurementAnalysisGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectLineMeasurementAnalysis(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectLineMeasurementAnalysisGenerated } = await import('./directLineMeasurementAnalysis.gb');
    return await buildDotNetDirectLineMeasurementAnalysisGenerated(jsObject, layerId, viewId);
}
