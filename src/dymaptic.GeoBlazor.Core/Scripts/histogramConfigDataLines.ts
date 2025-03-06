
export async function buildJsHistogramConfigDataLines(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramConfigDataLinesGenerated } = await import('./histogramConfigDataLines.gb');
    return await buildJsHistogramConfigDataLinesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramConfigDataLines(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHistogramConfigDataLinesGenerated } = await import('./histogramConfigDataLines.gb');
    return await buildDotNetHistogramConfigDataLinesGenerated(jsObject, layerId, viewId);
}
