
export async function buildJsIMeasurementViewModelActiveViewModel(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIMeasurementViewModelActiveViewModelGenerated } = await import('./iMeasurementViewModelActiveViewModel.gb');
    return await buildJsIMeasurementViewModelActiveViewModelGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIMeasurementViewModelActiveViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIMeasurementViewModelActiveViewModelGenerated } = await import('./iMeasurementViewModelActiveViewModel.gb');
    return await buildDotNetIMeasurementViewModelActiveViewModelGenerated(jsObject, viewId);
}
