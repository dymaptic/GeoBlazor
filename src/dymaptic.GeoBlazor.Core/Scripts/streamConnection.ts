
export async function buildJsStreamConnection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStreamConnectionGenerated } = await import('./streamConnection.gb');
    return await buildJsStreamConnectionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStreamConnection(jsObject: any): Promise<any> {
    let { buildDotNetStreamConnectionGenerated } = await import('./streamConnection.gb');
    return await buildDotNetStreamConnectionGenerated(jsObject);
}
