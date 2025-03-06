// override generated code in this file

export async function buildJsImageToMapMultirayParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageToMapMultirayParametersGenerated} = await import('./imageToMapMultirayParameters.gb');
    return await buildJsImageToMapMultirayParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageToMapMultirayParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageToMapMultirayParametersGenerated} = await import('./imageToMapMultirayParameters.gb');
    return await buildDotNetImageToMapMultirayParametersGenerated(jsObject, layerId, viewId);
}
