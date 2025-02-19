export async function buildJsDirectLineMeasurementAnalysisView3D(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectLineMeasurementAnalysisView3DGenerated } = await import('./directLineMeasurementAnalysisView3D.gb');
    return await buildJsDirectLineMeasurementAnalysisView3DGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetDirectLineMeasurementAnalysisView3D(jsObject: any): Promise<any> {
    let { buildDotNetDirectLineMeasurementAnalysisView3DGenerated } = await import('./directLineMeasurementAnalysisView3D.gb');
    return await buildDotNetDirectLineMeasurementAnalysisView3DGenerated(jsObject);
}
