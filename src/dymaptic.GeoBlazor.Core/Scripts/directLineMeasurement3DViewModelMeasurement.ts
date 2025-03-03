
export async function buildJsDirectLineMeasurement3DViewModelMeasurement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectLineMeasurement3DViewModelMeasurementGenerated } = await import('./directLineMeasurement3DViewModelMeasurement.gb');
    return await buildJsDirectLineMeasurement3DViewModelMeasurementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectLineMeasurement3DViewModelMeasurement(jsObject: any): Promise<any> {
    let { buildDotNetDirectLineMeasurement3DViewModelMeasurementGenerated } = await import('./directLineMeasurement3DViewModelMeasurement.gb');
    return await buildDotNetDirectLineMeasurement3DViewModelMeasurementGenerated(jsObject);
}
