
export async function buildJsPointCloudRendererColorModulation(dotNetObject: any): Promise<any> {
    let { buildJsPointCloudRendererColorModulationGenerated } = await import('./pointCloudRendererColorModulation.gb');
    return await buildJsPointCloudRendererColorModulationGenerated(dotNetObject);
}     

export async function buildDotNetPointCloudRendererColorModulation(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudRendererColorModulationGenerated } = await import('./pointCloudRendererColorModulation.gb');
    return await buildDotNetPointCloudRendererColorModulationGenerated(jsObject);
}
