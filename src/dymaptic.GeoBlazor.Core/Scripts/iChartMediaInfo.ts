export async function buildJsIChartMediaInfo(dotNetObject: any): Promise<any> {
    let {buildJsIChartMediaInfoGenerated} = await import('./iChartMediaInfo.gb');
    return buildJsIChartMediaInfoGenerated(dotNetObject);
}

export async function buildDotNetIChartMediaInfo(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetIChartMediaInfoGenerated} = await import('./iChartMediaInfo.gb');
    return await buildDotNetIChartMediaInfoGenerated(jsObject, viewId);
}
