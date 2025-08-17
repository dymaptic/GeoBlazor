
export async function buildJsRasterFunction(dotNetObject: any): Promise<any> {
    let { buildJsRasterFunctionGenerated } = await import('./rasterFunction.gb');
    return await buildJsRasterFunctionGenerated(dotNetObject);
}     

export async function buildDotNetRasterFunction(jsObject: any): Promise<any> {
    let { buildDotNetRasterFunctionGenerated } = await import('./rasterFunction.gb');
    return await buildDotNetRasterFunctionGenerated(jsObject);
}
