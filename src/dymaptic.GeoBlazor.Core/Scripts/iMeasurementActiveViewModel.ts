
export async function buildJsIMeasurementActiveViewModel(dotNetObject: any): Promise<any> {
    let { buildJsIMeasurementActiveViewModelGenerated } = await import('./iMeasurementActiveViewModel.gb');
    return buildJsIMeasurementActiveViewModelGenerated(dotNetObject);
}     

export async function buildDotNetIMeasurementActiveViewModel(jsObject: any): Promise<any> {
    let { buildDotNetIMeasurementActiveViewModelGenerated } = await import('./iMeasurementActiveViewModel.gb');
    return buildDotNetIMeasurementActiveViewModelGenerated(jsObject);
}
