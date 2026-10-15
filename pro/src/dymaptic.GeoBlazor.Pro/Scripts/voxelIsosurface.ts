
export async function buildJsVoxelIsosurface(dotNetObject: any): Promise<any> {
    let { buildJsVoxelIsosurfaceGenerated } = await import('./voxelIsosurface.gb');
    return await buildJsVoxelIsosurfaceGenerated(dotNetObject);
}     

export async function buildDotNetVoxelIsosurface(jsObject: any): Promise<any> {
    let { buildDotNetVoxelIsosurfaceGenerated } = await import('./voxelIsosurface.gb');
    return await buildDotNetVoxelIsosurfaceGenerated(jsObject);
}
