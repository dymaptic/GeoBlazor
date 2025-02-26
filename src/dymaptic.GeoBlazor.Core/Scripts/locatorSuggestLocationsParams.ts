
export async function buildJsLocatorSuggestLocationsParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocatorSuggestLocationsParamsGenerated } = await import('./locatorSuggestLocationsParams.gb');
    return await buildJsLocatorSuggestLocationsParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLocatorSuggestLocationsParams(jsObject: any): Promise<any> {
    let { buildDotNetLocatorSuggestLocationsParamsGenerated } = await import('./locatorSuggestLocationsParams.gb');
    return await buildDotNetLocatorSuggestLocationsParamsGenerated(jsObject);
}
