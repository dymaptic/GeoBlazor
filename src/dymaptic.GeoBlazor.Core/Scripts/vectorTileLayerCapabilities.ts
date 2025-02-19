// override generated code in this file

export async function buildJsVectorTileLayerCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVectorTileLayerCapabilitiesGenerated } = await import('./vectorTileLayerCapabilities.gb');
    return await buildJsVectorTileLayerCapabilitiesGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVectorTileLayerCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetVectorTileLayerCapabilitiesGenerated } = await import('./vectorTileLayerCapabilities.gb');
    return await buildDotNetVectorTileLayerCapabilitiesGenerated(jsObject);
}