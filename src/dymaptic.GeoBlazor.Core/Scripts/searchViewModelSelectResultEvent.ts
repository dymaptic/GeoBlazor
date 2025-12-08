
export async function buildJsSearchViewModelSelectResultEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSelectResultEventGenerated } = await import('./searchViewModelSelectResultEvent.gb');
    return await buildJsSearchViewModelSelectResultEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSelectResultEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSearchViewModelSelectResultEventGenerated } = await import('./searchViewModelSelectResultEvent.gb');
    return await buildDotNetSearchViewModelSelectResultEventGenerated(jsObject, viewId);
}
