
export async function buildJsSwipeViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSwipeViewModelGenerated } = await import('./swipeViewModel.gb');
    return await buildJsSwipeViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSwipeViewModel(jsObject: any): Promise<any> {
    let { buildDotNetSwipeViewModelGenerated } = await import('./swipeViewModel.gb');
    return await buildDotNetSwipeViewModelGenerated(jsObject);
}
