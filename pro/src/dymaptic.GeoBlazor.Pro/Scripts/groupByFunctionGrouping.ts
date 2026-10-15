
export async function buildJsGroupByFunctionGrouping(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupByFunctionGroupingGenerated } = await import('./groupByFunctionGrouping.gb');
    return await buildJsGroupByFunctionGroupingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupByFunctionGrouping(jsObject: any): Promise<any> {
    let { buildDotNetGroupByFunctionGroupingGenerated } = await import('./groupByFunctionGrouping.gb');
    return await buildDotNetGroupByFunctionGroupingGenerated(jsObject);
}
