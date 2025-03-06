
export async function buildJsSceneViewConstraintsClipDistance(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewConstraintsClipDistanceGenerated } = await import('./sceneViewConstraintsClipDistance.gb');
    return await buildJsSceneViewConstraintsClipDistanceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewConstraintsClipDistance(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewConstraintsClipDistanceGenerated } = await import('./sceneViewConstraintsClipDistance.gb');
    return await buildDotNetSceneViewConstraintsClipDistanceGenerated(jsObject, layerId, viewId);
}
