
export async function buildJsConsumedNodes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConsumedNodesGenerated } = await import('./consumedNodes.gb');
    return await buildJsConsumedNodesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConsumedNodes(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetConsumedNodesGenerated } = await import('./consumedNodes.gb');
    return await buildDotNetConsumedNodesGenerated(jsObject, layerId, viewId);
}
