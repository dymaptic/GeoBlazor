
export async function buildJsSizeRangeResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeRangeResultGenerated } = await import('./sizeRangeResult.gb');
    return await buildJsSizeRangeResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeRangeResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSizeRangeResultGenerated } = await import('./sizeRangeResult.gb');
    return await buildDotNetSizeRangeResultGenerated(jsObject, layerId, viewId);
}
