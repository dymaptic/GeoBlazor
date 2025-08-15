
export async function buildJsVoxelSlice(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVoxelSliceGenerated } = await import('./voxelSlice.gb');
    return await buildJsVoxelSliceGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVoxelSlice(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVoxelSliceGenerated } = await import('./voxelSlice.gb');
    return await buildDotNetVoxelSliceGenerated(jsObject, viewId);
}
