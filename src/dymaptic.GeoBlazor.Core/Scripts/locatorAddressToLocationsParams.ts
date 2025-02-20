export async function buildJsLocatorAddressToLocationsParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocatorAddressToLocationsParamsGenerated} = await import('./locatorAddressToLocationsParams.gb');
    return await buildJsLocatorAddressToLocationsParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocatorAddressToLocationsParams(jsObject: any): Promise<any> {
    let {buildDotNetLocatorAddressToLocationsParamsGenerated} = await import('./locatorAddressToLocationsParams.gb');
    return await buildDotNetLocatorAddressToLocationsParamsGenerated(jsObject);
}
