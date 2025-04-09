
export async function buildJsCurrentUserNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCurrentUserNodeGenerated } = await import('./currentUserNode.gb');
    return await buildJsCurrentUserNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCurrentUserNode(jsObject: any): Promise<any> {
    let { buildDotNetCurrentUserNodeGenerated } = await import('./currentUserNode.gb');
    return await buildDotNetCurrentUserNodeGenerated(jsObject);
}
