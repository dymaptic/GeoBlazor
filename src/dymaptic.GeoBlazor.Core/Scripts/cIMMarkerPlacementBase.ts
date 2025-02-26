
export async function buildJsCIMMarkerPlacementBase(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementBaseGenerated } = await import('./cIMMarkerPlacementBase.gb');
    return await buildJsCIMMarkerPlacementBaseGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementBase(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementBaseGenerated } = await import('./cIMMarkerPlacementBase.gb');
    return await buildDotNetCIMMarkerPlacementBaseGenerated(jsObject);
}
