
export async function buildJsAttributeBinsGrouping(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeBinsGroupingGenerated } = await import('./attributeBinsGrouping.gb');
    return await buildJsAttributeBinsGroupingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeBinsGrouping(jsObject: any): Promise<any> {
    let { buildDotNetAttributeBinsGroupingGenerated } = await import('./attributeBinsGrouping.gb');
    return await buildDotNetAttributeBinsGroupingGenerated(jsObject);
}
