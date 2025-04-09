
export async function buildJsBuildingSceneLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingSceneLayerSaveAsOptionsGenerated } = await import('./buildingSceneLayerSaveAsOptions.gb');
    return await buildJsBuildingSceneLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingSceneLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetBuildingSceneLayerSaveAsOptionsGenerated } = await import('./buildingSceneLayerSaveAsOptions.gb');
    return await buildDotNetBuildingSceneLayerSaveAsOptionsGenerated(jsObject);
}
