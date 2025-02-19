
export async function buildJsPlacesQueryResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPlacesQueryResultGenerated } = await import('./placesQueryResult.gb');
    return await buildJsPlacesQueryResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPlacesQueryResult(jsObject: any): Promise<any> {
    let { buildDotNetPlacesQueryResultGenerated } = await import('./placesQueryResult.gb');
    return await buildDotNetPlacesQueryResultGenerated(jsObject);
}
