export async function buildJsPlacesQueryParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPlacesQueryParametersGenerated} = await import('./placesQueryParameters.gb');
    return await buildJsPlacesQueryParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPlacesQueryParameters(jsObject: any): Promise<any> {
    let {buildDotNetPlacesQueryParametersGenerated} = await import('./placesQueryParameters.gb');
    return await buildDotNetPlacesQueryParametersGenerated(jsObject);
}
