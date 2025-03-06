
export async function buildJsElevationSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationSourceGenerated } = await import('./elevationSource.gb');
    return await buildJsElevationSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationSource(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetElevationSourceGenerated } = await import('./elevationSource.gb');
    return await buildDotNetElevationSourceGenerated(jsObject, layerId, viewId);
}
