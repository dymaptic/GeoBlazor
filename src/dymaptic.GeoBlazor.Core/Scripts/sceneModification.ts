export async function buildJsSceneModification(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneModificationGenerated } = await import('./sceneModification.gb');
    return await buildJsSceneModificationGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSceneModification(jsObject: any): Promise<any> {
    let { buildDotNetSceneModificationGenerated } = await import('./sceneModification.gb');
    return await buildDotNetSceneModificationGenerated(jsObject);
}
