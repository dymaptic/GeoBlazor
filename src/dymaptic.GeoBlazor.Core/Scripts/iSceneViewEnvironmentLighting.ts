
export async function buildJsISceneViewEnvironmentLighting(dotNetObject: any): Promise<any> {
    let { buildJsISceneViewEnvironmentLightingGenerated } = await import('./iSceneViewEnvironmentLighting.gb');
    return await buildJsISceneViewEnvironmentLightingGenerated(dotNetObject);
}     

export async function buildDotNetISceneViewEnvironmentLighting(jsObject: any): Promise<any> {
    let { buildDotNetISceneViewEnvironmentLightingGenerated } = await import('./iSceneViewEnvironmentLighting.gb');
    return await buildDotNetISceneViewEnvironmentLightingGenerated(jsObject);
}
