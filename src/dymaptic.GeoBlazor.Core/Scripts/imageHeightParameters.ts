// override generated code in this file

export async function buildJsImageHeightParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageHeightParametersGenerated} = await import('./imageHeightParameters.gb');
    return await buildJsImageHeightParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageHeightParameters(jsObject: any): Promise<any> {
    let {buildDotNetImageHeightParametersGenerated} = await import('./imageHeightParameters.gb');
    return await buildDotNetImageHeightParametersGenerated(jsObject);
}
