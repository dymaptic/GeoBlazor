
export async function buildJsVoxelColorStop(dotNetObject: any): Promise<any> {
    let { buildJsVoxelColorStopGenerated } = await import('./voxelColorStop.gb');
    return await buildJsVoxelColorStopGenerated(dotNetObject);
}     

export async function buildDotNetVoxelColorStop(jsObject: any): Promise<any> {
    let { buildDotNetVoxelColorStopGenerated } = await import('./voxelColorStop.gb');
    return await buildDotNetVoxelColorStopGenerated(jsObject);
}
