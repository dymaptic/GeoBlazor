
export async function buildJsRasterFunction(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsRasterFunctionGenerated } = await import('./rasterFunction.gb');
    return await buildJsRasterFunctionGenerated(dotNetObject, viewId);
}     

export async function buildDotNetRasterFunction(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRasterFunctionGenerated } = await import('./rasterFunction.gb');
    return await buildDotNetRasterFunctionGenerated(jsObject, viewId);
}
