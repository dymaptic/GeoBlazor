
export async function buildJsDateNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDateNodeGenerated } = await import('./dateNode.gb');
    return await buildJsDateNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDateNode(jsObject: any): Promise<any> {
    let { buildDotNetDateNodeGenerated } = await import('./dateNode.gb');
    return await buildDotNetDateNodeGenerated(jsObject);
}
