export async function buildJsLegendViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLegendViewModelGenerated} = await import('./legendViewModel.gb');
    return await buildJsLegendViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLegendViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetLegendViewModelGenerated} = await import('./legendViewModel.gb');
    return await buildDotNetLegendViewModelGenerated(jsObject, viewId);
}
