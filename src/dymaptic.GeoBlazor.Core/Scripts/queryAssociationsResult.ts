
export async function buildJsQueryAssociationsResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsQueryAssociationsResultGenerated } = await import('./queryAssociationsResult.gb');
    return await buildJsQueryAssociationsResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetQueryAssociationsResult(jsObject: any): Promise<any> {
    let { buildDotNetQueryAssociationsResultGenerated } = await import('./queryAssociationsResult.gb');
    return await buildDotNetQueryAssociationsResultGenerated(jsObject);
}
