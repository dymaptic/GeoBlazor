
export async function buildJsSimpleCaseNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSimpleCaseNodeGenerated } = await import('./simpleCaseNode.gb');
    return await buildJsSimpleCaseNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSimpleCaseNode(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSimpleCaseNodeGenerated } = await import('./simpleCaseNode.gb');
    return await buildDotNetSimpleCaseNodeGenerated(jsObject, layerId, viewId);
}
