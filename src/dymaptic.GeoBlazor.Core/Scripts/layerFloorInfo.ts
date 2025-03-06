
export async function buildJsLayerFloorInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildJsLayerFloorInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerFloorInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildDotNetLayerFloorInfoGenerated(jsObject, layerId, viewId);
}
