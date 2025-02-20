export async function buildJsLocatorLocationToAddressParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocatorLocationToAddressParamsGenerated} = await import('./locatorLocationToAddressParams.gb');
    return await buildJsLocatorLocationToAddressParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocatorLocationToAddressParams(jsObject: any): Promise<any> {
    let {buildDotNetLocatorLocationToAddressParamsGenerated} = await import('./locatorLocationToAddressParams.gb');
    return await buildDotNetLocatorLocationToAddressParamsGenerated(jsObject);
}
