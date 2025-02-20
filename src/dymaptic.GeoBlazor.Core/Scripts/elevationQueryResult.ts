export async function buildJsElevationQueryResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsElevationQueryResultGenerated} = await import('./elevationQueryResult.gb');
    return await buildJsElevationQueryResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetElevationQueryResult(jsObject: any): Promise<any> {
    let {buildDotNetElevationQueryResultGenerated} = await import('./elevationQueryResult.gb');
    return await buildDotNetElevationQueryResultGenerated(jsObject);
}
