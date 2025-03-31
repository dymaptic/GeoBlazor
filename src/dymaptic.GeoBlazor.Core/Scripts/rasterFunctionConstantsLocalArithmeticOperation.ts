
export async function buildJsRasterFunctionConstantsLocalArithmeticOperation(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionConstantsLocalArithmeticOperationGenerated } = await import('./rasterFunctionConstantsLocalArithmeticOperation.gb');
    return await buildJsRasterFunctionConstantsLocalArithmeticOperationGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterFunctionConstantsLocalArithmeticOperation(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRasterFunctionConstantsLocalArithmeticOperationGenerated } = await import('./rasterFunctionConstantsLocalArithmeticOperation.gb');
    return await buildDotNetRasterFunctionConstantsLocalArithmeticOperationGenerated(jsObject, layerId, viewId);
}
