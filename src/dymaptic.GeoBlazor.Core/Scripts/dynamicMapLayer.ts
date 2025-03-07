
export async function buildJsDynamicMapLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDynamicMapLayerGenerated } = await import('./dynamicMapLayer.gb');
    return await buildJsDynamicMapLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDynamicMapLayer(jsObject: any): Promise<any> {
    let { buildDotNetDynamicMapLayerGenerated } = await import('./dynamicMapLayer.gb');
    return await buildDotNetDynamicMapLayerGenerated(jsObject);
}
