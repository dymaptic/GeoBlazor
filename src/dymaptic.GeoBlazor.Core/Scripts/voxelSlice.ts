
export async function buildJsVoxelSlice(dotNetObject: any): Promise<any> {
    let { buildJsVoxelSliceGenerated } = await import('./voxelSlice.gb');
    return await buildJsVoxelSliceGenerated(dotNetObject);
}     

export async function buildDotNetVoxelSlice(jsObject: any): Promise<any> {
    let { buildDotNetVoxelSliceGenerated } = await import('./voxelSlice.gb');
    return await buildDotNetVoxelSliceGenerated(jsObject);
}
