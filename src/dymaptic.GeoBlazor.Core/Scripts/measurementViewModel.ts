
export async function buildJsMeasurementViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeasurementViewModelGenerated } = await import('./measurementViewModel.gb');
    return await buildJsMeasurementViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeasurementViewModel(jsObject: any): Promise<any> {
    let { buildDotNetMeasurementViewModelGenerated } = await import('./measurementViewModel.gb');
    return await buildDotNetMeasurementViewModelGenerated(jsObject);
}
