
export async function buildJsAreaMeasurement2DViewModelMeasurement(dotNetObject: any): Promise<any> {
    let { buildJsAreaMeasurement2DViewModelMeasurementGenerated } = await import('./areaMeasurement2DViewModelMeasurement.gb');
    return await buildJsAreaMeasurement2DViewModelMeasurementGenerated(dotNetObject);
}     

export async function buildDotNetAreaMeasurement2DViewModelMeasurement(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurement2DViewModelMeasurementGenerated } = await import('./areaMeasurement2DViewModelMeasurement.gb');
    return await buildDotNetAreaMeasurement2DViewModelMeasurementGenerated(jsObject);
}
