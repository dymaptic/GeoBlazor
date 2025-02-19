
export async function buildJsGeometryServiceToGeoCoordinateStringParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGeometryServiceToGeoCoordinateStringParamsGenerated } = await import('./geometryServiceToGeoCoordinateStringParams.gb');
    return await buildJsGeometryServiceToGeoCoordinateStringParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGeometryServiceToGeoCoordinateStringParams(jsObject: any): Promise<any> {
    let { buildDotNetGeometryServiceToGeoCoordinateStringParamsGenerated } = await import('./geometryServiceToGeoCoordinateStringParams.gb');
    return await buildDotNetGeometryServiceToGeoCoordinateStringParamsGenerated(jsObject);
}
