
export async function buildJsVoxelVolumeStyle(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVoxelVolumeStyleGenerated } = await import('./voxelVolumeStyle.gb');
    return await buildJsVoxelVolumeStyleGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVoxelVolumeStyle(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVoxelVolumeStyleGenerated } = await import('./voxelVolumeStyle.gb');
    return await buildDotNetVoxelVolumeStyleGenerated(jsObject, viewId);
}
