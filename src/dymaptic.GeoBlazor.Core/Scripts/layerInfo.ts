
export async function buildJsLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerInfoGenerated } = await import('./layerInfo.gb');
    return await buildJsLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerInfoGenerated } = await import('./layerInfo.gb');
    return await buildDotNetLayerInfoGenerated(jsObject, layerId, viewId);
}
