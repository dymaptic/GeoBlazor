
export async function buildJsPieChartSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartSchemesGenerated } = await import('./pieChartSchemes.gb');
    return await buildJsPieChartSchemesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPieChartSchemes(jsObject: any): Promise<any> {
    let { buildDotNetPieChartSchemesGenerated } = await import('./pieChartSchemes.gb');
    return await buildDotNetPieChartSchemesGenerated(jsObject);
}
