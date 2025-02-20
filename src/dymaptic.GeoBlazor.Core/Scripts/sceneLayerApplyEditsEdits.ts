export async function buildJsSceneLayerApplyEditsEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneLayerApplyEditsEditsGenerated} = await import('./sceneLayerApplyEditsEdits.gb');
    return await buildJsSceneLayerApplyEditsEditsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneLayerApplyEditsEdits(jsObject: any): Promise<any> {
    let {buildDotNetSceneLayerApplyEditsEditsGenerated} = await import('./sceneLayerApplyEditsEdits.gb');
    return await buildDotNetSceneLayerApplyEditsEditsGenerated(jsObject);
}
