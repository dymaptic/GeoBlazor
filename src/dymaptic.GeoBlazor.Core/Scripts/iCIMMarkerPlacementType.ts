
export async function buildJsICIMMarkerPlacementType(dotNetObject: any): Promise<any> {
    let { buildJsICIMMarkerPlacementTypeGenerated } = await import('./iCIMMarkerPlacementType.gb');
    return await buildJsICIMMarkerPlacementTypeGenerated(dotNetObject);
}     

export async function buildDotNetICIMMarkerPlacementType(jsObject: any): Promise<any> {
    let { buildDotNetICIMMarkerPlacementTypeGenerated } = await import('./iCIMMarkerPlacementType.gb');
    return await buildDotNetICIMMarkerPlacementTypeGenerated(jsObject);
}
