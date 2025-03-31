
export async function buildJsWebsceneSunLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebsceneSunLightingGenerated } = await import('./websceneSunLighting.gb');
    return await buildJsWebsceneSunLightingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebsceneSunLighting(jsObject: any): Promise<any> {
    let { buildDotNetWebsceneSunLightingGenerated } = await import('./websceneSunLighting.gb');
    return await buildDotNetWebsceneSunLightingGenerated(jsObject);
}
