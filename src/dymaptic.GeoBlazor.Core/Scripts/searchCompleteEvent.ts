
export async function buildJsSearchCompleteEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchCompleteEventGenerated } = await import('./searchCompleteEvent.gb');
    return await buildJsSearchCompleteEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchCompleteEvent(jsObject: any): Promise<any> {
    let { buildDotNetSearchCompleteEventGenerated } = await import('./searchCompleteEvent.gb');
    return await buildDotNetSearchCompleteEventGenerated(jsObject);
}
