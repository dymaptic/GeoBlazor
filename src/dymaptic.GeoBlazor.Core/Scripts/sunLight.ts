
export async function buildJsSunLight(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSunLightGenerated } = await import('./sunLight.gb');
    return await buildJsSunLightGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSunLight(jsObject: any): Promise<any> {
    let { buildDotNetSunLightGenerated } = await import('./sunLight.gb');
    return await buildDotNetSunLightGenerated(jsObject);
}
