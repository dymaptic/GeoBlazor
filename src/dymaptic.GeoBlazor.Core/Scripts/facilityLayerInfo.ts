
export async function buildJsFacilityLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFacilityLayerInfoGenerated } = await import('./facilityLayerInfo.gb');
    return await buildJsFacilityLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFacilityLayerInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFacilityLayerInfoGenerated } = await import('./facilityLayerInfo.gb');
    return await buildDotNetFacilityLayerInfoGenerated(jsObject, viewId);
}
