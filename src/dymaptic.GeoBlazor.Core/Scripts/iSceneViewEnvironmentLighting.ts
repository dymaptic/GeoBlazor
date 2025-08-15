
export async function buildJsISceneViewEnvironmentLighting(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsISceneViewEnvironmentLightingGenerated } = await import('./iSceneViewEnvironmentLighting.gb');
    return await buildJsISceneViewEnvironmentLightingGenerated(dotNetObject, viewId);
}     

export async function buildDotNetISceneViewEnvironmentLighting(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetISceneViewEnvironmentLightingGenerated } = await import('./iSceneViewEnvironmentLighting.gb');
    return await buildDotNetISceneViewEnvironmentLightingGenerated(jsObject, viewId);
}
