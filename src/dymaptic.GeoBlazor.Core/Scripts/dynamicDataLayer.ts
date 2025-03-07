export async function buildJsDynamicDataLayer(dotNetObject: any): Promise<any> {
    let {buildJsDynamicDataLayerGenerated} = await import('./dynamicDataLayer.gb');
    return await buildJsDynamicDataLayerGenerated(dotNetObject);
}

export async function buildDotNetDynamicDataLayer(jsObject: any): Promise<any> {
    let {buildDotNetDynamicDataLayerGenerated} = await import('./dynamicDataLayer.gb');
    return await buildDotNetDynamicDataLayerGenerated(jsObject);
}
