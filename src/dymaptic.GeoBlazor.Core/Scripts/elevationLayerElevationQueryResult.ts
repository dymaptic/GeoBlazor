export async function buildJsElevationLayerElevationQueryResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsElevationLayerElevationQueryResultGenerated} = await import('./elevationLayerElevationQueryResult.gb');
    return await buildJsElevationLayerElevationQueryResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetElevationLayerElevationQueryResult(jsObject: any): Promise<any> {
    let {buildDotNetElevationLayerElevationQueryResultGenerated} = await import('./elevationLayerElevationQueryResult.gb');
    return await buildDotNetElevationLayerElevationQueryResultGenerated(jsObject);
}
