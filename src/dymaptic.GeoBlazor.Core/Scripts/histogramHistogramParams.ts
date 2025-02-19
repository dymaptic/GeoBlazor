export async function buildJsHistogramHistogramParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramHistogramParamsGenerated } = await import('./histogramHistogramParams.gb');
    return await buildJsHistogramHistogramParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetHistogramHistogramParams(jsObject: any): Promise<any> {
    let { buildDotNetHistogramHistogramParamsGenerated } = await import('./histogramHistogramParams.gb');
    return await buildDotNetHistogramHistogramParamsGenerated(jsObject);
}
