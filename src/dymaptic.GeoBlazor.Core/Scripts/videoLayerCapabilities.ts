
export async function buildJsVideoLayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVideoLayerCapabilitiesGenerated } = await import('./videoLayerCapabilities.gb');
    return await buildJsVideoLayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVideoLayerCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVideoLayerCapabilitiesGenerated } = await import('./videoLayerCapabilities.gb');
    return await buildDotNetVideoLayerCapabilitiesGenerated(jsObject, layerId, viewId);
}
