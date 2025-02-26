
export async function buildJsUnaryNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnaryNodeGenerated } = await import('./unaryNode.gb');
    return await buildJsUnaryNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnaryNode(jsObject: any): Promise<any> {
    let { buildDotNetUnaryNodeGenerated } = await import('./unaryNode.gb');
    return await buildDotNetUnaryNodeGenerated(jsObject);
}
