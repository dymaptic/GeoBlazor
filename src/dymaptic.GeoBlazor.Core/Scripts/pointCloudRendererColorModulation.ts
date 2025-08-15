
export async function buildJsPointCloudRendererColorModulation(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPointCloudRendererColorModulationGenerated } = await import('./pointCloudRendererColorModulation.gb');
    return await buildJsPointCloudRendererColorModulationGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPointCloudRendererColorModulation(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPointCloudRendererColorModulationGenerated } = await import('./pointCloudRendererColorModulation.gb');
    return await buildDotNetPointCloudRendererColorModulationGenerated(jsObject, viewId);
}
