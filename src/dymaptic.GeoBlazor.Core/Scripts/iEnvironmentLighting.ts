
export async function buildJsIEnvironmentLighting(dotNetObject: any): Promise<any> {
    let { buildJsIEnvironmentLightingGenerated } = await import('./iEnvironmentLighting.gb');
    return await buildJsIEnvironmentLightingGenerated(dotNetObject);
}     

export async function buildDotNetIEnvironmentLighting(jsObject: any): Promise<any> {
    let { buildDotNetIEnvironmentLightingGenerated } = await import('./iEnvironmentLighting.gb');
    return await buildDotNetIEnvironmentLightingGenerated(jsObject);
}
