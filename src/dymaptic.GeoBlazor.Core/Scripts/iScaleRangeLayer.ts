
export async function buildJsIScaleRangeLayer(dotNetObject: any): Promise<any> {
    let { buildJsIScaleRangeLayerGenerated } = await import('./iScaleRangeLayer.gb');
    return await buildJsIScaleRangeLayerGenerated(dotNetObject);
}     

export async function buildDotNetIScaleRangeLayer(jsObject: any): Promise<any> {
    let { buildDotNetIScaleRangeLayerGenerated } = await import('./iScaleRangeLayer.gb');
    return await buildDotNetIScaleRangeLayerGenerated(jsObject);
}
