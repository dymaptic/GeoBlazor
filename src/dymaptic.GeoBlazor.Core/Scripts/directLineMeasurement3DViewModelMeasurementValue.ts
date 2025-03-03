
export async function buildJsDirectLineMeasurement3DViewModelMeasurementValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectLineMeasurement3DViewModelMeasurementValueGenerated } = await import('./directLineMeasurement3DViewModelMeasurementValue.gb');
    return await buildJsDirectLineMeasurement3DViewModelMeasurementValueGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectLineMeasurement3DViewModelMeasurementValue(jsObject: any): Promise<any> {
    let { buildDotNetDirectLineMeasurement3DViewModelMeasurementValueGenerated } = await import('./directLineMeasurement3DViewModelMeasurementValue.gb');
    return await buildDotNetDirectLineMeasurement3DViewModelMeasurementValueGenerated(jsObject);
}
