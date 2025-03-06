
export async function buildJsSceneViewEnvironmentAtmosphere(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewEnvironmentAtmosphereGenerated } = await import('./sceneViewEnvironmentAtmosphere.gb');
    return await buildJsSceneViewEnvironmentAtmosphereGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewEnvironmentAtmosphere(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewEnvironmentAtmosphereGenerated } = await import('./sceneViewEnvironmentAtmosphere.gb');
    return await buildDotNetSceneViewEnvironmentAtmosphereGenerated(jsObject, layerId, viewId);
}
