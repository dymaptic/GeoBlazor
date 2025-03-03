
export async function buildJsButtonMenuViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsButtonMenuViewModelGenerated } = await import('./buttonMenuViewModel.gb');
    return await buildJsButtonMenuViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetButtonMenuViewModel(jsObject: any): Promise<any> {
    let { buildDotNetButtonMenuViewModelGenerated } = await import('./buttonMenuViewModel.gb');
    return await buildDotNetButtonMenuViewModelGenerated(jsObject);
}
