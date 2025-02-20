export async function buildJsVoxelVariableStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVoxelVariableStyleGenerated} = await import('./voxelVariableStyle.gb');
    return await buildJsVoxelVariableStyleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVoxelVariableStyle(jsObject: any): Promise<any> {
    let {buildDotNetVoxelVariableStyleGenerated} = await import('./voxelVariableStyle.gb');
    return await buildDotNetVoxelVariableStyleGenerated(jsObject);
}
