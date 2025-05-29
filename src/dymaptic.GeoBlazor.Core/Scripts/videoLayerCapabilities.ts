
export async function buildJsVideoLayerCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsVideoLayerCapabilitiesGenerated } = await import('./videoLayerCapabilities.gb');
    return await buildJsVideoLayerCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetVideoLayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetVideoLayerCapabilitiesGenerated } = await import('./videoLayerCapabilities.gb');
    return await buildDotNetVideoLayerCapabilitiesGenerated(jsObject);
}
