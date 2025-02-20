export async function buildJsISceneService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsISceneServiceGenerated} = await import('./iSceneService.gb');
    return await buildJsISceneServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetISceneService(jsObject: any): Promise<any> {
    let {buildDotNetISceneServiceGenerated} = await import('./iSceneService.gb');
    return await buildDotNetISceneServiceGenerated(jsObject);
}
