
export async function buildJsHistogramDataLines(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramDataLinesGenerated } = await import('./histogramDataLines.gb');
    return await buildJsHistogramDataLinesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramDataLines(jsObject: any): Promise<any> {
    let { buildDotNetHistogramDataLinesGenerated } = await import('./histogramDataLines.gb');
    return await buildDotNetHistogramDataLinesGenerated(jsObject);
}
