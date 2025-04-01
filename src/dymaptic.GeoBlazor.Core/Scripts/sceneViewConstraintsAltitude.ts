
export async function buildJsSceneViewConstraintsAltitude(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewConstraintsAltitudeGenerated } = await import('./sceneViewConstraintsAltitude.gb');
    return await buildJsSceneViewConstraintsAltitudeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewConstraintsAltitude(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewConstraintsAltitudeGenerated } = await import('./sceneViewConstraintsAltitude.gb');
    return await buildDotNetSceneViewConstraintsAltitudeGenerated(jsObject, layerId, viewId);
}
