
export async function buildJsRasterHistogram(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterHistogramGenerated } = await import('./rasterHistogram.gb');
    return await buildJsRasterHistogramGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterHistogram(jsObject: any): Promise<any> {
    let { buildDotNetRasterHistogramGenerated } = await import('./rasterHistogram.gb');
    return await buildDotNetRasterHistogramGenerated(jsObject);
}
