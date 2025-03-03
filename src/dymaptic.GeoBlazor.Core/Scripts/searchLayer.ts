
export async function buildJsSearchLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchLayerGenerated } = await import('./searchLayer.gb');
    return await buildJsSearchLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchLayer(jsObject: any): Promise<any> {
    let { buildDotNetSearchLayerGenerated } = await import('./searchLayer.gb');
    return await buildDotNetSearchLayerGenerated(jsObject);
}
