
export async function buildJsIChartMediaInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIChartMediaInfoGenerated } = await import('./iChartMediaInfo.gb');
    return await buildJsIChartMediaInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIChartMediaInfo(jsObject: any): Promise<any> {
    let { buildDotNetIChartMediaInfoGenerated } = await import('./iChartMediaInfo.gb');
    return await buildDotNetIChartMediaInfoGenerated(jsObject);
}
