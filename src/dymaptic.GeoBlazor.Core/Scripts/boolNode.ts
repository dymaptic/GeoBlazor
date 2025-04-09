
export async function buildJsBoolNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBoolNodeGenerated } = await import('./boolNode.gb');
    return await buildJsBoolNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBoolNode(jsObject: any): Promise<any> {
    let { buildDotNetBoolNodeGenerated } = await import('./boolNode.gb');
    return await buildDotNetBoolNodeGenerated(jsObject);
}
