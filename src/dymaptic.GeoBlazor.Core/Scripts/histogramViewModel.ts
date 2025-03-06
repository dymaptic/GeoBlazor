
export async function buildJsHistogramViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramViewModelGenerated } = await import('./histogramViewModel.gb');
    return await buildJsHistogramViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHistogramViewModelGenerated } = await import('./histogramViewModel.gb');
    return await buildDotNetHistogramViewModelGenerated(jsObject, layerId, viewId);
}
