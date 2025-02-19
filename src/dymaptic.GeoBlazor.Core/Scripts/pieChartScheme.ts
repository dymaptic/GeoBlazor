
export async function buildJsPieChartScheme(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartSchemeGenerated } = await import('./pieChartScheme.gb');
    return await buildJsPieChartSchemeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPieChartScheme(jsObject: any): Promise<any> {
    let { buildDotNetPieChartSchemeGenerated } = await import('./pieChartScheme.gb');
    return await buildDotNetPieChartSchemeGenerated(jsObject);
}
