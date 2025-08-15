
export async function buildJsVoxelOpacityStop(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVoxelOpacityStopGenerated } = await import('./voxelOpacityStop.gb');
    return await buildJsVoxelOpacityStopGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVoxelOpacityStop(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVoxelOpacityStopGenerated } = await import('./voxelOpacityStop.gb');
    return await buildDotNetVoxelOpacityStopGenerated(jsObject, viewId);
}
