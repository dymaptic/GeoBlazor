
export async function buildJsCIMMarkerPlacementAlongLineVariableSize(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementAlongLineVariableSizeGenerated } = await import('./cIMMarkerPlacementAlongLineVariableSize.gb');
    return await buildJsCIMMarkerPlacementAlongLineVariableSizeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementAlongLineVariableSize(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementAlongLineVariableSizeGenerated } = await import('./cIMMarkerPlacementAlongLineVariableSize.gb');
    return await buildDotNetCIMMarkerPlacementAlongLineVariableSizeGenerated(jsObject);
}
