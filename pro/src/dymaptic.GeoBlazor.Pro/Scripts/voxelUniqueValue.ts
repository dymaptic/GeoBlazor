
export async function buildJsVoxelUniqueValue(dotNetObject: any): Promise<any> {
    let { buildJsVoxelUniqueValueGenerated } = await import('./voxelUniqueValue.gb');
    return await buildJsVoxelUniqueValueGenerated(dotNetObject);
}     

export async function buildDotNetVoxelUniqueValue(jsObject: any): Promise<any> {
    let { buildDotNetVoxelUniqueValueGenerated } = await import('./voxelUniqueValue.gb');
    return await buildDotNetVoxelUniqueValueGenerated(jsObject);
}
