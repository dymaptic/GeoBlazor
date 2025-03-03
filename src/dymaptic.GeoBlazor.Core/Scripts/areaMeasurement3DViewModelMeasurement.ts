
export async function buildJsAreaMeasurement3DViewModelMeasurement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurement3DViewModelMeasurementGenerated } = await import('./areaMeasurement3DViewModelMeasurement.gb');
    return await buildJsAreaMeasurement3DViewModelMeasurementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurement3DViewModelMeasurement(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurement3DViewModelMeasurementGenerated } = await import('./areaMeasurement3DViewModelMeasurement.gb');
    return await buildDotNetAreaMeasurement3DViewModelMeasurementGenerated(jsObject);
}
