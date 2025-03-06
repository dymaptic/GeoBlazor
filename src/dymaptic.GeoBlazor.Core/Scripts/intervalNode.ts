
export async function buildJsIntervalNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIntervalNodeGenerated } = await import('./intervalNode.gb');
    return await buildJsIntervalNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIntervalNode(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIntervalNodeGenerated } = await import('./intervalNode.gb');
    return await buildDotNetIntervalNodeGenerated(jsObject, layerId, viewId);
}
