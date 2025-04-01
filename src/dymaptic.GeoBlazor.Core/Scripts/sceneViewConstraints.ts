
export async function buildJsSceneViewConstraints(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewConstraintsGenerated } = await import('./sceneViewConstraints.gb');
    return await buildJsSceneViewConstraintsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewConstraints(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewConstraintsGenerated } = await import('./sceneViewConstraints.gb');
    return await buildDotNetSceneViewConstraintsGenerated(jsObject, layerId, viewId);
}
