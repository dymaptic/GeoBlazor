
export async function buildJsSceneModification(dotNetObject: any): Promise<any> {
    let { buildJsSceneModificationGenerated } = await import('./sceneModification.gb');
    return await buildJsSceneModificationGenerated(dotNetObject);
}     

export async function buildDotNetSceneModification(jsObject: any): Promise<any> {
    let { buildDotNetSceneModificationGenerated } = await import('./sceneModification.gb');
    return await buildDotNetSceneModificationGenerated(jsObject);
}
