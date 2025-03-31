
export async function buildJsExpandViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsExpandViewModelGenerated } = await import('./expandViewModel.gb');
    return await buildJsExpandViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetExpandViewModel(jsObject: any): Promise<any> {
    let { buildDotNetExpandViewModelGenerated } = await import('./expandViewModel.gb');
    return await buildDotNetExpandViewModelGenerated(jsObject);
}
