
export async function buildJsVoxelVariableStyle(dotNetObject: any): Promise<any> {
    let { buildJsVoxelVariableStyleGenerated } = await import('./voxelVariableStyle.gb');
    return await buildJsVoxelVariableStyleGenerated(dotNetObject);
}     

export async function buildDotNetVoxelVariableStyle(jsObject: any): Promise<any> {
    let { buildDotNetVoxelVariableStyleGenerated } = await import('./voxelVariableStyle.gb');
    return await buildDotNetVoxelVariableStyleGenerated(jsObject);
}
