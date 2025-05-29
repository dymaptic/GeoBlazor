
export async function buildJsVoxelVoxelVolumeStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelVoxelVolumeStyleGenerated } = await import('./voxelVoxelVolumeStyle.gb');
    return await buildJsVoxelVoxelVolumeStyleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVoxelVoxelVolumeStyle(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVoxelVoxelVolumeStyleGenerated } = await import('./voxelVoxelVolumeStyle.gb');
    return await buildDotNetVoxelVoxelVolumeStyleGenerated(jsObject, layerId, viewId);
}
