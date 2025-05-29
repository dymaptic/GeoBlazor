export async function buildJsSceneViewEnvironment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSceneViewEnvironmentGenerated} = await import('./sceneViewEnvironment.gb');
    return await buildJsSceneViewEnvironmentGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSceneViewEnvironment(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetSceneViewEnvironmentGenerated} = await import('./sceneViewEnvironment.gb');
    return await buildDotNetSceneViewEnvironmentGenerated(jsObject, layerId, viewId);
}
