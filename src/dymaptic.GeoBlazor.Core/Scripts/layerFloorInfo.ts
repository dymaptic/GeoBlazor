
export async function buildJsLayerFloorInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildJsLayerFloorInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetLayerFloorInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildDotNetLayerFloorInfoGenerated(jsObject, viewId);
}
