
export async function buildJsPixelBlockStatistics(dotNetObject: any): Promise<any> {
    let { buildJsPixelBlockStatisticsGenerated } = await import('./pixelBlockStatistics.gb');
    return await buildJsPixelBlockStatisticsGenerated(dotNetObject);
}     

export async function buildDotNetPixelBlockStatistics(jsObject: any): Promise<any> {
    let { buildDotNetPixelBlockStatisticsGenerated } = await import('./pixelBlockStatistics.gb');
    return await buildDotNetPixelBlockStatisticsGenerated(jsObject);
}
