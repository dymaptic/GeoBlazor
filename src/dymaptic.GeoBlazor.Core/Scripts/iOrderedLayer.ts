
export async function buildJsIOrderedLayer(dotNetObject: any): Promise<any> {
    let { buildJsIOrderedLayerGenerated } = await import('./iOrderedLayer.gb');
    return await buildJsIOrderedLayerGenerated(dotNetObject);
}     

export async function buildDotNetIOrderedLayer(jsObject: any): Promise<any> {
    let { buildDotNetIOrderedLayerGenerated } = await import('./iOrderedLayer.gb');
    return await buildDotNetIOrderedLayerGenerated(jsObject);
}
