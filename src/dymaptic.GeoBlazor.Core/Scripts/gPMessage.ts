
export async function buildJsGPMessage(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGPMessageGenerated } = await import('./gPMessage.gb');
    return await buildJsGPMessageGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGPMessage(jsObject: any): Promise<any> {
    let { buildDotNetGPMessageGenerated } = await import('./gPMessage.gb');
    return await buildDotNetGPMessageGenerated(jsObject);
}
