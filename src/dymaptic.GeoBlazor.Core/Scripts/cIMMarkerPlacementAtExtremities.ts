
export async function buildJsCIMMarkerPlacementAtExtremities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementAtExtremitiesGenerated } = await import('./cIMMarkerPlacementAtExtremities.gb');
    return await buildJsCIMMarkerPlacementAtExtremitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementAtExtremities(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementAtExtremitiesGenerated } = await import('./cIMMarkerPlacementAtExtremities.gb');
    return await buildDotNetCIMMarkerPlacementAtExtremitiesGenerated(jsObject);
}
