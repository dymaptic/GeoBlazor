
export async function buildJsVoxelSlice(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelSliceGenerated } = await import('./voxelSlice.gb');
    return await buildJsVoxelSliceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVoxelSlice(jsObject: any): Promise<any> {
    let { buildDotNetVoxelSliceGenerated } = await import('./voxelSlice.gb');
    return await buildDotNetVoxelSliceGenerated(jsObject);
}
