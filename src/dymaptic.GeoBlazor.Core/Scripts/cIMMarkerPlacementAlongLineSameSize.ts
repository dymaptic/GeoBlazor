
export async function buildJsCIMMarkerPlacementAlongLineSameSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementAlongLineSameSizeGenerated } = await import('./cIMMarkerPlacementAlongLineSameSize.gb');
    return await buildJsCIMMarkerPlacementAlongLineSameSizeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementAlongLineSameSize(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementAlongLineSameSizeGenerated } = await import('./cIMMarkerPlacementAlongLineSameSize.gb');
    return await buildDotNetCIMMarkerPlacementAlongLineSameSizeGenerated(jsObject);
}
