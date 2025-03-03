
export async function buildJsPixelBlockStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPixelBlockStatisticsGenerated } = await import('./pixelBlockStatistics.gb');
    return await buildJsPixelBlockStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPixelBlockStatistics(jsObject: any): Promise<any> {
    let { buildDotNetPixelBlockStatisticsGenerated } = await import('./pixelBlockStatistics.gb');
    return await buildDotNetPixelBlockStatisticsGenerated(jsObject);
}
