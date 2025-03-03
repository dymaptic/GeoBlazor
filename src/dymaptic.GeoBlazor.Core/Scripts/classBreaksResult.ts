
export async function buildJsClassBreaksResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassBreaksResultGenerated } = await import('./classBreaksResult.gb');
    return await buildJsClassBreaksResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassBreaksResult(jsObject: any): Promise<any> {
    let { buildDotNetClassBreaksResultGenerated } = await import('./classBreaksResult.gb');
    return await buildDotNetClassBreaksResultGenerated(jsObject);
}
