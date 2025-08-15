export async function buildJsDynamicDataLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDynamicDataLayerGenerated} = await import('./dynamicDataLayer.gb');
    return await buildJsDynamicDataLayerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDynamicDataLayer(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetDynamicDataLayerGenerated} = await import('./dynamicDataLayer.gb');
    return await buildDotNetDynamicDataLayerGenerated(jsObject, viewId);
}
