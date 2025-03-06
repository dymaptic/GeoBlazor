
export async function buildJsOrderedLayerOrderBy(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrderedLayerOrderByGenerated } = await import('./orderedLayerOrderBy.gb');
    return await buildJsOrderedLayerOrderByGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrderedLayerOrderBy(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetOrderedLayerOrderByGenerated } = await import('./orderedLayerOrderBy.gb');
    return await buildDotNetOrderedLayerOrderByGenerated(jsObject, layerId, viewId);
}
