
export async function buildJsSceneLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneLayerSaveAsOptionsGenerated } = await import('./sceneLayerSaveAsOptions.gb');
    return await buildJsSceneLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetSceneLayerSaveAsOptionsGenerated } = await import('./sceneLayerSaveAsOptions.gb');
    return await buildDotNetSceneLayerSaveAsOptionsGenerated(jsObject);
}
