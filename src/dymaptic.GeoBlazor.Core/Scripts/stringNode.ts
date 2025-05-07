
export async function buildJsStringNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStringNodeGenerated } = await import('./stringNode.gb');
    return await buildJsStringNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStringNode(jsObject: any): Promise<any> {
    let { buildDotNetStringNodeGenerated } = await import('./stringNode.gb');
    return await buildDotNetStringNodeGenerated(jsObject);
}
