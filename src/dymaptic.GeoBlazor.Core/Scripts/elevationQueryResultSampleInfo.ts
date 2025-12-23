
export async function buildJsElevationQueryResultSampleInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationQueryResultSampleInfoGenerated } = await import('./elevationQueryResultSampleInfo.gb');
    return await buildJsElevationQueryResultSampleInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationQueryResultSampleInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetElevationQueryResultSampleInfoGenerated } = await import('./elevationQueryResultSampleInfo.gb');
    return await buildDotNetElevationQueryResultSampleInfoGenerated(jsObject, viewId);
}
