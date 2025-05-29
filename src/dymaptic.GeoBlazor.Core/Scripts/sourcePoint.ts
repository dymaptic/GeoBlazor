
export async function buildJsSourcePoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSourcePointGenerated } = await import('./sourcePoint.gb');
    return await buildJsSourcePointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSourcePoint(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSourcePointGenerated } = await import('./sourcePoint.gb');
    return await buildDotNetSourcePointGenerated(jsObject, layerId, viewId);
}
