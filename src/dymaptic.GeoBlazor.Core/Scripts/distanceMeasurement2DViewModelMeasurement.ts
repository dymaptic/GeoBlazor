
export async function buildJsDistanceMeasurement2DViewModelMeasurement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDistanceMeasurement2DViewModelMeasurementGenerated } = await import('./distanceMeasurement2DViewModelMeasurement.gb');
    return await buildJsDistanceMeasurement2DViewModelMeasurementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDistanceMeasurement2DViewModelMeasurement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDistanceMeasurement2DViewModelMeasurementGenerated } = await import('./distanceMeasurement2DViewModelMeasurement.gb');
    return await buildDotNetDistanceMeasurement2DViewModelMeasurementGenerated(jsObject, layerId, viewId);
}
