
export async function buildJsSearchSelectResultEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchSelectResultEventGenerated } = await import('./searchSelectResultEvent.gb');
    return await buildJsSearchSelectResultEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchSelectResultEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSearchSelectResultEventGenerated } = await import('./searchSelectResultEvent.gb');
    return await buildDotNetSearchSelectResultEventGenerated(jsObject, layerId, viewId);
}
