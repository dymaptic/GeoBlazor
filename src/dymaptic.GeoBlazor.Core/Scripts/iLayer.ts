export async function buildDotNetILayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetILayerGenerated } = await import('./iLayer.gb');
    return await buildDotNetILayerGenerated(jsObject, layerId, viewId);
}

export async function buildJsILayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsILayerGenerated } = await import('./iLayer.gb');
    return await buildJsILayerGenerated(dotNetObject, layerId, viewId);
}
