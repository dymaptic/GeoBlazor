export async function buildJsVoxelColorStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelColorStopGenerated } = await import('./voxelColorStop.gb');
    return await buildJsVoxelColorStopGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVoxelColorStop(jsObject: any): Promise<any> {
    let { buildDotNetVoxelColorStopGenerated } = await import('./voxelColorStop.gb');
    return await buildDotNetVoxelColorStopGenerated(jsObject);
}
