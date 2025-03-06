
export async function buildJsHistogramConfig(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsHistogramConfigGenerated } = await import('./histogramConfig.gb');
    return await buildJsHistogramConfigGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetHistogramConfig(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetHistogramConfigGenerated } = await import('./histogramConfig.gb');
    return await buildDotNetHistogramConfigGenerated(jsObject, layerId, viewId);
}
