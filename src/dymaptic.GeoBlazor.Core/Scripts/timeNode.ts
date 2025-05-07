
export async function buildJsTimeNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeNodeGenerated } = await import('./timeNode.gb');
    return await buildJsTimeNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeNode(jsObject: any): Promise<any> {
    let { buildDotNetTimeNodeGenerated } = await import('./timeNode.gb');
    return await buildDotNetTimeNodeGenerated(jsObject);
}
