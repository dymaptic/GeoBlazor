
export async function buildJsWebsceneVirtualLighting(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebsceneVirtualLightingGenerated } = await import('./websceneVirtualLighting.gb');
    return await buildJsWebsceneVirtualLightingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebsceneVirtualLighting(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetWebsceneVirtualLightingGenerated } = await import('./websceneVirtualLighting.gb');
    return await buildDotNetWebsceneVirtualLightingGenerated(jsObject, layerId, viewId);
}
