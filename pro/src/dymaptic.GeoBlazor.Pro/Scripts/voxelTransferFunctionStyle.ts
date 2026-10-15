
export async function buildJsVoxelTransferFunctionStyle(dotNetObject: any): Promise<any> {
    let { buildJsVoxelTransferFunctionStyleGenerated } = await import('./voxelTransferFunctionStyle.gb');
    return await buildJsVoxelTransferFunctionStyleGenerated(dotNetObject);
}     

export async function buildDotNetVoxelTransferFunctionStyle(jsObject: any): Promise<any> {
    let { buildDotNetVoxelTransferFunctionStyleGenerated } = await import('./voxelTransferFunctionStyle.gb');
    return await buildDotNetVoxelTransferFunctionStyleGenerated(jsObject);
}
