
export async function buildJsHistogramRangeSliderDataLines(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramRangeSliderDataLinesGenerated } = await import('./histogramRangeSliderDataLines.gb');
    return await buildJsHistogramRangeSliderDataLinesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramRangeSliderDataLines(jsObject: any): Promise<any> {
    let { buildDotNetHistogramRangeSliderDataLinesGenerated } = await import('./histogramRangeSliderDataLines.gb');
    return await buildDotNetHistogramRangeSliderDataLinesGenerated(jsObject);
}
