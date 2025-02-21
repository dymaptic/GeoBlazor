
export async function buildJsScaleRangeScaleRangeParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsScaleRangeScaleRangeParamsGenerated } = await import('./scaleRangeScaleRangeParams.gb');
    return await buildJsScaleRangeScaleRangeParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetScaleRangeScaleRangeParams(jsObject: any): Promise<any> {
    let { buildDotNetScaleRangeScaleRangeParamsGenerated } = await import('./scaleRangeScaleRangeParams.gb');
    return await buildDotNetScaleRangeScaleRangeParamsGenerated(jsObject);
}
