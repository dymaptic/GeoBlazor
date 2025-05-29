
export async function buildJsIBlendLayer(dotNetObject: any): Promise<any> {
    let { buildJsIBlendLayerGenerated } = await import('./iBlendLayer.gb');
    return await buildJsIBlendLayerGenerated(dotNetObject);
}     

export async function buildDotNetIBlendLayer(jsObject: any): Promise<any> {
    let { buildDotNetIBlendLayerGenerated } = await import('./iBlendLayer.gb');
    return await buildDotNetIBlendLayerGenerated(jsObject);
}
