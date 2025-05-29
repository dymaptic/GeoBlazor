
export async function buildJsNumberNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNumberNodeGenerated } = await import('./numberNode.gb');
    return await buildJsNumberNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNumberNode(jsObject: any): Promise<any> {
    let { buildDotNetNumberNodeGenerated } = await import('./numberNode.gb');
    return await buildDotNetNumberNodeGenerated(jsObject);
}
