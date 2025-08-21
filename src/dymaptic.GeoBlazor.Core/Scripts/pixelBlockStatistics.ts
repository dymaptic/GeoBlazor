
export async function buildJsPixelBlockStatistics(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPixelBlockStatisticsGenerated } = await import('./pixelBlockStatistics.gb');
    return await buildJsPixelBlockStatisticsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPixelBlockStatistics(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPixelBlockStatisticsGenerated } = await import('./pixelBlockStatistics.gb');
    return await buildDotNetPixelBlockStatisticsGenerated(jsObject, viewId);
}
