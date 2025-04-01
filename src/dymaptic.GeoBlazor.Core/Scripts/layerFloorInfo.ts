
export async function buildJsLayerFloorInfo(dotNetObject: any): Promise<any> {
    let { buildJsLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildJsLayerFloorInfoGenerated(dotNetObject);
}     

export async function buildDotNetLayerFloorInfo(jsObject: any): Promise<any> {
    let { buildDotNetLayerFloorInfoGenerated } = await import('./layerFloorInfo.gb');
    return await buildDotNetLayerFloorInfoGenerated(jsObject);
}
