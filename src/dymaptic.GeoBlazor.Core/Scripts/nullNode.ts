
export async function buildJsNullNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNullNodeGenerated } = await import('./nullNode.gb');
    return await buildJsNullNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNullNode(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetNullNodeGenerated } = await import('./nullNode.gb');
    return await buildDotNetNullNodeGenerated(jsObject, viewId);
}
