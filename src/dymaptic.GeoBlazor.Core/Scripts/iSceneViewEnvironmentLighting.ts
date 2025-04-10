
export async function buildJsISceneViewEnvironmentLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISceneViewEnvironmentLightingGenerated } = await import('./iSceneViewEnvironmentLighting.gb');
    return await buildJsISceneViewEnvironmentLightingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISceneViewEnvironmentLighting(jsObject: any): Promise<any> {
    let { buildDotNetISceneViewEnvironmentLightingGenerated } = await import('./iSceneViewEnvironmentLighting.gb');
    return await buildDotNetISceneViewEnvironmentLightingGenerated(jsObject);
}
