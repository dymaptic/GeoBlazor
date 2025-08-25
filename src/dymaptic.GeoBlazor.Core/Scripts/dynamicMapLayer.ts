
export async function buildJsDynamicMapLayer(dotNetObject: any): Promise<any> {
    let { buildJsDynamicMapLayerGenerated } = await import('./dynamicMapLayer.gb');
    return await buildJsDynamicMapLayerGenerated(dotNetObject);
}     

export async function buildDotNetDynamicMapLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetDynamicMapLayerGenerated } = await import('./dynamicMapLayer.gb');
    return await buildDotNetDynamicMapLayerGenerated(jsObject, viewId);
}
