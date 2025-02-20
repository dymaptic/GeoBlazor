export async function buildJsAttributionViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsAttributionViewModelGenerated} = await import('./attributionViewModel.gb');
    return await buildJsAttributionViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetAttributionViewModel(jsObject: any): Promise<any> {
    let {buildDotNetAttributionViewModelGenerated} = await import('./attributionViewModel.gb');
    return await buildDotNetAttributionViewModelGenerated(jsObject);
}
