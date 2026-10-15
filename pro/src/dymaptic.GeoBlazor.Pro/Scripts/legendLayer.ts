
export async function buildJsLegendLayer(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLegendLayerGenerated } = await import('./legendLayer.gb');
    return await buildJsLegendLayerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLegendLayer(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLegendLayerGenerated } = await import('./legendLayer.gb');
    return await buildDotNetLegendLayerGenerated(jsObject, layerId, viewId);
}
