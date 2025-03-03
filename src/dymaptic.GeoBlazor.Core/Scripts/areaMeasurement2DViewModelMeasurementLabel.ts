
export async function buildJsAreaMeasurement2DViewModelMeasurementLabel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAreaMeasurement2DViewModelMeasurementLabelGenerated } = await import('./areaMeasurement2DViewModelMeasurementLabel.gb');
    return await buildJsAreaMeasurement2DViewModelMeasurementLabelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAreaMeasurement2DViewModelMeasurementLabel(jsObject: any): Promise<any> {
    let { buildDotNetAreaMeasurement2DViewModelMeasurementLabelGenerated } = await import('./areaMeasurement2DViewModelMeasurementLabel.gb');
    return await buildDotNetAreaMeasurement2DViewModelMeasurementLabelGenerated(jsObject);
}
