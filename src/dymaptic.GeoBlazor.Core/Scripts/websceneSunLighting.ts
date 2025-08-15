
export async function buildJsWebsceneSunLighting(dotNetObject: any): Promise<any> {
    let { buildJsWebsceneSunLightingGenerated } = await import('./websceneSunLighting.gb');
    return await buildJsWebsceneSunLightingGenerated(dotNetObject);
}     

export async function buildDotNetWebsceneSunLighting(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWebsceneSunLightingGenerated } = await import('./websceneSunLighting.gb');
    return await buildDotNetWebsceneSunLightingGenerated(jsObject, viewId);
}
