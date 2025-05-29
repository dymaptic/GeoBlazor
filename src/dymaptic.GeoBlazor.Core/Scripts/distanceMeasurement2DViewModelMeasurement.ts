
export async function buildJsDistanceMeasurement2DViewModelMeasurement(dotNetObject: any): Promise<any> {
    let { buildJsDistanceMeasurement2DViewModelMeasurementGenerated } = await import('./distanceMeasurement2DViewModelMeasurement.gb');
    return await buildJsDistanceMeasurement2DViewModelMeasurementGenerated(dotNetObject);
}     

export async function buildDotNetDistanceMeasurement2DViewModelMeasurement(jsObject: any): Promise<any> {
    let { buildDotNetDistanceMeasurement2DViewModelMeasurementGenerated } = await import('./distanceMeasurement2DViewModelMeasurement.gb');
    return await buildDotNetDistanceMeasurement2DViewModelMeasurementGenerated(jsObject);
}
