
export async function buildJsRasterStretchColorrampResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRasterStretchColorrampResultGenerated } = await import('./rasterStretchColorrampResult.gb');
    return await buildJsRasterStretchColorrampResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRasterStretchColorrampResult(jsObject: any): Promise<any> {
    let { buildDotNetRasterStretchColorrampResultGenerated } = await import('./rasterStretchColorrampResult.gb');
    return await buildDotNetRasterStretchColorrampResultGenerated(jsObject);
}
