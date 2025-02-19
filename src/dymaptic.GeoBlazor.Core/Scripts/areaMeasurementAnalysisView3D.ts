
export async function buildJsAreaMeasurementAnalysisView3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurementAnalysisView3DGenerated } = await import('./areaMeasurementAnalysisView3D.gb');
    return await buildJsAreaMeasurementAnalysisView3DGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurementAnalysisView3D(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurementAnalysisView3DGenerated } = await import('./areaMeasurementAnalysisView3D.gb');
    return await buildDotNetAreaMeasurementAnalysisView3DGenerated(jsObject);
}
