
export async function buildJsVoxelVolumeStyle(dotNetObject: any): Promise<any> {
    let { buildJsVoxelVolumeStyleGenerated } = await import('./voxelVolumeStyle.gb');
    return await buildJsVoxelVolumeStyleGenerated(dotNetObject);
}     

export async function buildDotNetVoxelVolumeStyle(jsObject: any): Promise<any> {
    let { buildDotNetVoxelVolumeStyleGenerated } = await import('./voxelVolumeStyle.gb');
    return await buildDotNetVoxelVolumeStyleGenerated(jsObject);
}
