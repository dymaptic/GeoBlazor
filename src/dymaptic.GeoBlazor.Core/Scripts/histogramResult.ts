
export async function buildJsHistogramResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramResultGenerated } = await import('./histogramResult.gb');
    return await buildJsHistogramResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHistogramResultGenerated } = await import('./histogramResult.gb');
    return await buildDotNetHistogramResultGenerated(jsObject, layerId, viewId);
}
