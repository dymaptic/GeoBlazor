// override generated code in this file

export async function buildJsImageDistanceParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageDistanceParametersGenerated} = await import('./imageDistanceParameters.gb');
    return await buildJsImageDistanceParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageDistanceParameters(jsObject: any): Promise<any> {
    let {buildDotNetImageDistanceParametersGenerated} = await import('./imageDistanceParameters.gb');
    return await buildDotNetImageDistanceParametersGenerated(jsObject);
}
