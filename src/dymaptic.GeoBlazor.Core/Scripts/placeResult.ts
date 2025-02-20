export async function buildJsPlaceResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPlaceResultGenerated} = await import('./placeResult.gb');
    return await buildJsPlaceResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPlaceResult(jsObject: any): Promise<any> {
    let {buildDotNetPlaceResultGenerated} = await import('./placeResult.gb');
    return await buildDotNetPlaceResultGenerated(jsObject);
}
