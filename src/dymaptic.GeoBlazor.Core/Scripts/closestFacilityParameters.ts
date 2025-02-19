
export async function buildJsClosestFacilityParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClosestFacilityParametersGenerated } = await import('./closestFacilityParameters.gb');
    return await buildJsClosestFacilityParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClosestFacilityParameters(jsObject: any): Promise<any> {
    let { buildDotNetClosestFacilityParametersGenerated } = await import('./closestFacilityParameters.gb');
    return await buildDotNetClosestFacilityParametersGenerated(jsObject);
}
