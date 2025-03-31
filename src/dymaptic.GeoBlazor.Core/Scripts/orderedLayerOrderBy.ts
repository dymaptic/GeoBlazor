
export async function buildJsOrderedLayerOrderBy(dotNetObject: any): Promise<any> {
    let { buildJsOrderedLayerOrderByGenerated } = await import('./orderedLayerOrderBy.gb');
    return await buildJsOrderedLayerOrderByGenerated(dotNetObject);
}     

export async function buildDotNetOrderedLayerOrderBy(jsObject: any): Promise<any> {
    let { buildDotNetOrderedLayerOrderByGenerated } = await import('./orderedLayerOrderBy.gb');
    return await buildDotNetOrderedLayerOrderByGenerated(jsObject);
}
