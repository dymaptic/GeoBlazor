export async function buildJsPointCloudUniqueValueRendererColorUniqueValueInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudUniqueValueRendererColorUniqueValueInfosGenerated } = await import('./pointCloudUniqueValueRendererColorUniqueValueInfos.gb');
    return await buildJsPointCloudUniqueValueRendererColorUniqueValueInfosGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetPointCloudUniqueValueRendererColorUniqueValueInfos(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudUniqueValueRendererColorUniqueValueInfosGenerated } = await import('./pointCloudUniqueValueRendererColorUniqueValueInfos.gb');
    return await buildDotNetPointCloudUniqueValueRendererColorUniqueValueInfosGenerated(jsObject);
}
