
export async function buildJsWebsceneVirtualLighting(dotNetObject: any): Promise<any> {
    let { buildJsWebsceneVirtualLightingGenerated } = await import('./websceneVirtualLighting.gb');
    return await buildJsWebsceneVirtualLightingGenerated(dotNetObject);
}     

export async function buildDotNetWebsceneVirtualLighting(jsObject: any): Promise<any> {
    let { buildDotNetWebsceneVirtualLightingGenerated } = await import('./websceneVirtualLighting.gb');
    return await buildDotNetWebsceneVirtualLightingGenerated(jsObject);
}
