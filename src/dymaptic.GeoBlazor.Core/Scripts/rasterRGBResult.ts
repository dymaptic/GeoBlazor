
export async function buildJsRasterRGBResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterRGBResultGenerated } = await import('./rasterRGBResult.gb');
    return await buildJsRasterRGBResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterRGBResult(jsObject: any): Promise<any> {
    let { buildDotNetRasterRGBResultGenerated } = await import('./rasterRGBResult.gb');
    return await buildDotNetRasterRGBResultGenerated(jsObject);
}
