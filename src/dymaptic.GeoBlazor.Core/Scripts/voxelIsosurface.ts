export async function buildJsVoxelIsosurface(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelIsosurfaceGenerated } = await import('./voxelIsosurface.gb');
    return await buildJsVoxelIsosurfaceGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVoxelIsosurface(jsObject: any): Promise<any> {
    let { buildDotNetVoxelIsosurfaceGenerated } = await import('./voxelIsosurface.gb');
    return await buildDotNetVoxelIsosurfaceGenerated(jsObject);
}
