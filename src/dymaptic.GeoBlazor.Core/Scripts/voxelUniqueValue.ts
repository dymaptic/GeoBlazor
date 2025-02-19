export async function buildJsVoxelUniqueValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelUniqueValueGenerated } = await import('./voxelUniqueValue.gb');
    return await buildJsVoxelUniqueValueGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetVoxelUniqueValue(jsObject: any): Promise<any> {
    let { buildDotNetVoxelUniqueValueGenerated } = await import('./voxelUniqueValue.gb');
    return await buildDotNetVoxelUniqueValueGenerated(jsObject);
}
