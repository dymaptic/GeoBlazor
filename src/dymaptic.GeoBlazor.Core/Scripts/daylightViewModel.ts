
export async function buildJsDaylightViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDaylightViewModelGenerated } = await import('./daylightViewModel.gb');
    return await buildJsDaylightViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDaylightViewModel(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDaylightViewModelGenerated } = await import('./daylightViewModel.gb');
    return await buildDotNetDaylightViewModelGenerated(jsObject, layerId, viewId);
}
