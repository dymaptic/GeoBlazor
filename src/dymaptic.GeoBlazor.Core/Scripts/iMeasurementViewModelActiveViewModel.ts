
export async function buildJsIMeasurementViewModelActiveViewModel(dotNetObject: any): Promise<any> {
    let { buildJsIMeasurementViewModelActiveViewModelGenerated } = await import('./iMeasurementViewModelActiveViewModel.gb');
    return await buildJsIMeasurementViewModelActiveViewModelGenerated(dotNetObject);
}     

export async function buildDotNetIMeasurementViewModelActiveViewModel(jsObject: any): Promise<any> {
    let { buildDotNetIMeasurementViewModelActiveViewModelGenerated } = await import('./iMeasurementViewModelActiveViewModel.gb');
    return await buildDotNetIMeasurementViewModelActiveViewModelGenerated(jsObject);
}
