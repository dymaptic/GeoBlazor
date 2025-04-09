
export async function buildJsPieChartRampElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPieChartRampElementGenerated } = await import('./pieChartRampElement.gb');
    return await buildJsPieChartRampElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPieChartRampElement(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPieChartRampElementGenerated } = await import('./pieChartRampElement.gb');
    return await buildDotNetPieChartRampElementGenerated(jsObject, layerId, viewId);
}
