
export async function buildJsWFSLayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSLayerCapabilitiesGenerated } = await import('./wFSLayerCapabilities.gb');
    return await buildJsWFSLayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWFSLayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetWFSLayerCapabilitiesGenerated } = await import('./wFSLayerCapabilities.gb');
    return await buildDotNetWFSLayerCapabilitiesGenerated(jsObject);
}
