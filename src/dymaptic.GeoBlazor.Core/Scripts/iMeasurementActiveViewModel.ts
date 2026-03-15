
export async function buildJsIMeasurementActiveViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIMeasurementActiveViewModelGenerated } = await import('./iMeasurementActiveViewModel.gb');
    return await buildJsIMeasurementActiveViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIMeasurementActiveViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIMeasurementActiveViewModelGenerated } = await import('./iMeasurementActiveViewModel.gb');
    return await buildDotNetIMeasurementActiveViewModelGenerated(jsObject, layerId, viewId);
}
