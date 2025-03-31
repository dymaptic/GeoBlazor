
export async function buildJsSceneViewConstraintsTilt(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewConstraintsTiltGenerated } = await import('./sceneViewConstraintsTilt.gb');
    return await buildJsSceneViewConstraintsTiltGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewConstraintsTilt(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewConstraintsTiltGenerated } = await import('./sceneViewConstraintsTilt.gb');
    return await buildDotNetSceneViewConstraintsTiltGenerated(jsObject, layerId, viewId);
}
