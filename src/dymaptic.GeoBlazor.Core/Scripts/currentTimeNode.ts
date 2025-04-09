
export async function buildJsCurrentTimeNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCurrentTimeNodeGenerated } = await import('./currentTimeNode.gb');
    return await buildJsCurrentTimeNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCurrentTimeNode(jsObject: any): Promise<any> {
    let { buildDotNetCurrentTimeNodeGenerated } = await import('./currentTimeNode.gb');
    return await buildDotNetCurrentTimeNodeGenerated(jsObject);
}
