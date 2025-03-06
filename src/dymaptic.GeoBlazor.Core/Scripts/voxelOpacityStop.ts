
export async function buildJsVoxelOpacityStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelOpacityStopGenerated } = await import('./voxelOpacityStop.gb');
    return await buildJsVoxelOpacityStopGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVoxelOpacityStop(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVoxelOpacityStopGenerated } = await import('./voxelOpacityStop.gb');
    return await buildDotNetVoxelOpacityStopGenerated(jsObject, layerId, viewId);
}
