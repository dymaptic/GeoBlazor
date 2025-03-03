
export async function buildJsAreaMeasurement3DViewModelMeasurementValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurement3DViewModelMeasurementValueGenerated } = await import('./areaMeasurement3DViewModelMeasurementValue.gb');
    return await buildJsAreaMeasurement3DViewModelMeasurementValueGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurement3DViewModelMeasurementValue(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurement3DViewModelMeasurementValueGenerated } = await import('./areaMeasurement3DViewModelMeasurementValue.gb');
    return await buildDotNetAreaMeasurement3DViewModelMeasurementValueGenerated(jsObject);
}
