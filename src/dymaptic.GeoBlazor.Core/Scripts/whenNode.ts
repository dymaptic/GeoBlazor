
export async function buildJsWhenNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWhenNodeGenerated } = await import('./whenNode.gb');
    return await buildJsWhenNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWhenNode(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWhenNodeGenerated } = await import('./whenNode.gb');
    return await buildDotNetWhenNodeGenerated(jsObject, layerId, viewId);
}
