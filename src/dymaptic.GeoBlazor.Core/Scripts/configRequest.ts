
export async function buildJsConfigRequest(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConfigRequestGenerated } = await import('./configRequest.gb');
    return await buildJsConfigRequestGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConfigRequest(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetConfigRequestGenerated } = await import('./configRequest.gb');
    return await buildDotNetConfigRequestGenerated(jsObject, layerId, viewId);
}
