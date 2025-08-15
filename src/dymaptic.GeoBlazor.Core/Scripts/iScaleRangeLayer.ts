
export async function buildJsIScaleRangeLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIScaleRangeLayerGenerated } = await import('./iScaleRangeLayer.gb');
    return await buildJsIScaleRangeLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIScaleRangeLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIScaleRangeLayerGenerated } = await import('./iScaleRangeLayer.gb');
    return await buildDotNetIScaleRangeLayerGenerated(jsObject, viewId);
}
