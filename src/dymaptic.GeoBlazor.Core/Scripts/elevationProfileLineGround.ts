
export async function buildJsElevationProfileLineGround(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationProfileLineGroundGenerated } = await import('./elevationProfileLineGround.gb');
    return await buildJsElevationProfileLineGroundGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationProfileLineGround(jsObject: any): Promise<any> {
    let { buildDotNetElevationProfileLineGroundGenerated } = await import('./elevationProfileLineGround.gb');
    return await buildDotNetElevationProfileLineGroundGenerated(jsObject);
}
