
export async function buildJsSunLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSunLightingGenerated } = await import('./sunLighting.gb');
    return await buildJsSunLightingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSunLighting(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSunLightingGenerated } = await import('./sunLighting.gb');
    return await buildDotNetSunLightingGenerated(jsObject, viewId);
}
