
export async function buildJsPointCloudClassBreaksRendererColorClassBreakInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPointCloudClassBreaksRendererColorClassBreakInfosGenerated } = await import('./pointCloudClassBreaksRendererColorClassBreakInfos.gb');
    return await buildJsPointCloudClassBreaksRendererColorClassBreakInfosGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPointCloudClassBreaksRendererColorClassBreakInfos(jsObject: any): Promise<any> {
    let { buildDotNetPointCloudClassBreaksRendererColorClassBreakInfosGenerated } = await import('./pointCloudClassBreaksRendererColorClassBreakInfos.gb');
    return await buildDotNetPointCloudClassBreaksRendererColorClassBreakInfosGenerated(jsObject);
}
