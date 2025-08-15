
export async function buildJsVideoLayerCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVideoLayerCapabilitiesGenerated } = await import('./videoLayerCapabilities.gb');
    return await buildJsVideoLayerCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVideoLayerCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVideoLayerCapabilitiesGenerated } = await import('./videoLayerCapabilities.gb');
    return await buildDotNetVideoLayerCapabilitiesGenerated(jsObject, viewId);
}
