
export async function buildJsSearchViewModelSearchCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSearchCompleteEventGenerated } = await import('./searchViewModelSearchCompleteEvent.gb');
    return await buildJsSearchViewModelSearchCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSearchCompleteEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSearchViewModelSearchCompleteEventGenerated } = await import('./searchViewModelSearchCompleteEvent.gb');
    return await buildDotNetSearchViewModelSearchCompleteEventGenerated(jsObject, viewId);
}
