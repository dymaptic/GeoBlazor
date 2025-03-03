
export async function buildJsCIMMarkerPlacementAlongLine(dotNetObject: any): Promise<any> {
    let { buildJsCIMMarkerPlacementAlongLineGenerated } = await import('./cIMMarkerPlacementAlongLine.gb');
    return await buildJsCIMMarkerPlacementAlongLineGenerated(dotNetObject);
}     

export async function buildDotNetCIMMarkerPlacementAlongLine(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementAlongLineGenerated } = await import('./cIMMarkerPlacementAlongLine.gb');
    return await buildDotNetCIMMarkerPlacementAlongLineGenerated(jsObject);
}
