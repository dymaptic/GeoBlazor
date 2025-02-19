
export async function buildJsSceneLayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneLayerGetFieldDomainOptionsGenerated } = await import('./sceneLayerGetFieldDomainOptions.gb');
    return await buildJsSceneLayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneLayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let { buildDotNetSceneLayerGetFieldDomainOptionsGenerated } = await import('./sceneLayerGetFieldDomainOptions.gb');
    return await buildDotNetSceneLayerGetFieldDomainOptionsGenerated(jsObject);
}
