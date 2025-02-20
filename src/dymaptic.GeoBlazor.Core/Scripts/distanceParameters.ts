export async function buildJsDistanceParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDistanceParametersGenerated} = await import('./distanceParameters.gb');
    return await buildJsDistanceParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDistanceParameters(jsObject: any): Promise<any> {
    let {buildDotNetDistanceParametersGenerated} = await import('./distanceParameters.gb');
    return await buildDotNetDistanceParametersGenerated(jsObject);
}
