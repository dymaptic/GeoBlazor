
export async function buildJsRasterValueToColor(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterValueToColorGenerated } = await import('./rasterValueToColor.gb');
    return await buildJsRasterValueToColorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterValueToColor(jsObject: any): Promise<any> {
    let { buildDotNetRasterValueToColorGenerated } = await import('./rasterValueToColor.gb');
    return await buildDotNetRasterValueToColorGenerated(jsObject);
}
