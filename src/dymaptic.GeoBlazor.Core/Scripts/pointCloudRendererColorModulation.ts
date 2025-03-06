
export async function buildJsPointCloudRendererColorModulation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudRendererColorModulationGenerated } = await import('./pointCloudRendererColorModulation.gb');
    return await buildJsPointCloudRendererColorModulationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudRendererColorModulation(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudRendererColorModulationGenerated } = await import('./pointCloudRendererColorModulation.gb');
    return await buildDotNetPointCloudRendererColorModulationGenerated(jsObject, layerId, viewId);
}
