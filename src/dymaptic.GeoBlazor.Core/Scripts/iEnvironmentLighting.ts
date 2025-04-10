
export async function buildJsIEnvironmentLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIEnvironmentLightingGenerated } = await import('./iEnvironmentLighting.gb');
    return await buildJsIEnvironmentLightingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIEnvironmentLighting(jsObject: any): Promise<any> {
    let { buildDotNetIEnvironmentLightingGenerated } = await import('./iEnvironmentLighting.gb');
    return await buildDotNetIEnvironmentLightingGenerated(jsObject);
}
