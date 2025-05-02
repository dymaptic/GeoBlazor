
export async function buildJsParamNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsParamNodeGenerated } = await import('./paramNode.gb');
    return await buildJsParamNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetParamNode(jsObject: any): Promise<any> {
    let { buildDotNetParamNodeGenerated } = await import('./paramNode.gb');
    return await buildDotNetParamNodeGenerated(jsObject);
}
