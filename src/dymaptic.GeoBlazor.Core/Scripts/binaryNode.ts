
export async function buildJsBinaryNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBinaryNodeGenerated } = await import('./binaryNode.gb');
    return await buildJsBinaryNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBinaryNode(jsObject: any): Promise<any> {
    let { buildDotNetBinaryNodeGenerated } = await import('./binaryNode.gb');
    return await buildDotNetBinaryNodeGenerated(jsObject);
}
