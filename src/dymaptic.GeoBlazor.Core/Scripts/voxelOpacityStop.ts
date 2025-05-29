
export async function buildJsVoxelOpacityStop(dotNetObject: any): Promise<any> {
    let { buildJsVoxelOpacityStopGenerated } = await import('./voxelOpacityStop.gb');
    return await buildJsVoxelOpacityStopGenerated(dotNetObject);
}     

export async function buildDotNetVoxelOpacityStop(jsObject: any): Promise<any> {
    let { buildDotNetVoxelOpacityStopGenerated } = await import('./voxelOpacityStop.gb');
    return await buildDotNetVoxelOpacityStopGenerated(jsObject);
}
