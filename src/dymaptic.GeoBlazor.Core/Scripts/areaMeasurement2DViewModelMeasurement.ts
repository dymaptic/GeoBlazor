
export async function buildJsAreaMeasurement2DViewModelMeasurement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurement2DViewModelMeasurementGenerated } = await import('./areaMeasurement2DViewModelMeasurement.gb');
    return await buildJsAreaMeasurement2DViewModelMeasurementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurement2DViewModelMeasurement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAreaMeasurement2DViewModelMeasurementGenerated } = await import('./areaMeasurement2DViewModelMeasurement.gb');
    return await buildDotNetAreaMeasurement2DViewModelMeasurementGenerated(jsObject, layerId, viewId);
}
