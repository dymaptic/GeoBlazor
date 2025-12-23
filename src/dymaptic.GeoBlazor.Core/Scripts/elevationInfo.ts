
export async function buildJsElevationInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationInfoGenerated } = await import('./elevationInfo.gb');
    return await buildJsElevationInfoGenerated(dotNetObject);
}     

export async function buildDotNetElevationInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetElevationInfoGenerated } = await import('./elevationInfo.gb');
    return await buildDotNetElevationInfoGenerated(jsObject);
}
