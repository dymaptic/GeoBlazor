export async function buildJsGeometryServiceFromGeoCoordinateStringParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeometryServiceFromGeoCoordinateStringParamsGenerated} = await import('./geometryServiceFromGeoCoordinateStringParams.gb');
    return await buildJsGeometryServiceFromGeoCoordinateStringParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeometryServiceFromGeoCoordinateStringParams(jsObject: any): Promise<any> {
    let {buildDotNetGeometryServiceFromGeoCoordinateStringParamsGenerated} = await import('./geometryServiceFromGeoCoordinateStringParams.gb');
    return await buildDotNetGeometryServiceFromGeoCoordinateStringParamsGenerated(jsObject);
}
