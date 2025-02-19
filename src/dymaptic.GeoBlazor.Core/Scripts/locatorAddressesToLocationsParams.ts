export async function buildJsLocatorAddressesToLocationsParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocatorAddressesToLocationsParamsGenerated } = await import('./locatorAddressesToLocationsParams.gb');
    return await buildJsLocatorAddressesToLocationsParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLocatorAddressesToLocationsParams(jsObject: any): Promise<any> {
    let { buildDotNetLocatorAddressesToLocationsParamsGenerated } = await import('./locatorAddressesToLocationsParams.gb');
    return await buildDotNetLocatorAddressesToLocationsParamsGenerated(jsObject);
}
