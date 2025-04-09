
export async function buildJsColumnNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColumnNodeGenerated } = await import('./columnNode.gb');
    return await buildJsColumnNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColumnNode(jsObject: any): Promise<any> {
    let { buildDotNetColumnNodeGenerated } = await import('./columnNode.gb');
    return await buildDotNetColumnNodeGenerated(jsObject);
}
