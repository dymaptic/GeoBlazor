export async function buildJsElevationProfileLineQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileLineQueryGenerated } = await import('./elevationProfileLineQuery.gb');
    return await buildJsElevationProfileLineQueryGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetElevationProfileLineQuery(jsObject: any): Promise<any> {
    let { buildDotNetElevationProfileLineQueryGenerated } = await import('./elevationProfileLineQuery.gb');
    return await buildDotNetElevationProfileLineQueryGenerated(jsObject);
}
