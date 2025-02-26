
export async function buildJsListNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsListNodeGenerated } = await import('./listNode.gb');
    return await buildJsListNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetListNode(jsObject: any): Promise<any> {
    let { buildDotNetListNodeGenerated } = await import('./listNode.gb');
    return await buildDotNetListNodeGenerated(jsObject);
}
