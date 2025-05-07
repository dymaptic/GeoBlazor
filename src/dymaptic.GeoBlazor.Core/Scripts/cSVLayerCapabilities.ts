
export async function buildJsCSVLayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerCapabilitiesGenerated } = await import('./cSVLayerCapabilities.gb');
    return await buildJsCSVLayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetCSVLayerCapabilitiesGenerated } = await import('./cSVLayerCapabilities.gb');
    return await buildDotNetCSVLayerCapabilitiesGenerated(jsObject);
}
