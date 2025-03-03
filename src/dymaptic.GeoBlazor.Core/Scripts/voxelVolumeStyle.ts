
export async function buildJsVoxelVolumeStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelVolumeStyleGenerated } = await import('./voxelVolumeStyle.gb');
    return await buildJsVoxelVolumeStyleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVoxelVolumeStyle(jsObject: any): Promise<any> {
    let { buildDotNetVoxelVolumeStyleGenerated } = await import('./voxelVolumeStyle.gb');
    return await buildDotNetVoxelVolumeStyleGenerated(jsObject);
}
