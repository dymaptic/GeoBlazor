
export async function buildJsPixelBlockAddDataPlaneDataStatistics(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPixelBlockAddDataPlaneDataStatisticsGenerated } = await import('./pixelBlockAddDataPlaneDataStatistics.gb');
    return await buildJsPixelBlockAddDataPlaneDataStatisticsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPixelBlockAddDataPlaneDataStatistics(jsObject: any): Promise<any> {
    let { buildDotNetPixelBlockAddDataPlaneDataStatisticsGenerated } = await import('./pixelBlockAddDataPlaneDataStatistics.gb');
    return await buildDotNetPixelBlockAddDataPlaneDataStatisticsGenerated(jsObject);
}
