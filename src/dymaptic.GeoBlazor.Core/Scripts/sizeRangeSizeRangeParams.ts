
export async function buildJsSizeRangeSizeRangeParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeRangeSizeRangeParamsGenerated } = await import('./sizeRangeSizeRangeParams.gb');
    return await buildJsSizeRangeSizeRangeParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeRangeSizeRangeParams(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSizeRangeSizeRangeParamsGenerated } = await import('./sizeRangeSizeRangeParams.gb');
    return await buildDotNetSizeRangeSizeRangeParamsGenerated(jsObject, layerId, viewId);
}
