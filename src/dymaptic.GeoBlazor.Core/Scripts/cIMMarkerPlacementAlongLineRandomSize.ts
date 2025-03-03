
export async function buildJsCIMMarkerPlacementAlongLineRandomSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementAlongLineRandomSizeGenerated } = await import('./cIMMarkerPlacementAlongLineRandomSize.gb');
    return await buildJsCIMMarkerPlacementAlongLineRandomSizeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementAlongLineRandomSize(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementAlongLineRandomSizeGenerated } = await import('./cIMMarkerPlacementAlongLineRandomSize.gb');
    return await buildDotNetCIMMarkerPlacementAlongLineRandomSizeGenerated(jsObject);
}
