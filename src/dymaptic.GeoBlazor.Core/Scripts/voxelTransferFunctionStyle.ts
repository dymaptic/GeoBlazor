
export async function buildJsVoxelTransferFunctionStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVoxelTransferFunctionStyleGenerated } = await import('./voxelTransferFunctionStyle.gb');
    return await buildJsVoxelTransferFunctionStyleGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVoxelTransferFunctionStyle(jsObject: any): Promise<any> {
    let { buildDotNetVoxelTransferFunctionStyleGenerated } = await import('./voxelTransferFunctionStyle.gb');
    return await buildDotNetVoxelTransferFunctionStyleGenerated(jsObject);
}
