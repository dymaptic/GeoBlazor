
export async function buildJsPixelValueRangeMap(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPixelValueRangeMapGenerated } = await import('./pixelValueRangeMap.gb');
    return await buildJsPixelValueRangeMapGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPixelValueRangeMap(jsObject: any): Promise<any> {
    let { buildDotNetPixelValueRangeMapGenerated } = await import('./pixelValueRangeMap.gb');
    return await buildDotNetPixelValueRangeMapGenerated(jsObject);
}
