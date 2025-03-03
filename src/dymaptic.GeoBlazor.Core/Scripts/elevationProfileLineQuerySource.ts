
export async function buildJsElevationProfileLineQuerySource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileLineQuerySourceGenerated } = await import('./elevationProfileLineQuerySource.gb');
    return await buildJsElevationProfileLineQuerySourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationProfileLineQuerySource(jsObject: any): Promise<any> {
    let { buildDotNetElevationProfileLineQuerySourceGenerated } = await import('./elevationProfileLineQuerySource.gb');
    return await buildDotNetElevationProfileLineQuerySourceGenerated(jsObject);
}
