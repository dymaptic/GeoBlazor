// override generated code in this file

export async function buildJsImageToMapParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageToMapParametersGenerated} = await import('./imageToMapParameters.gb');
    return await buildJsImageToMapParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageToMapParameters(jsObject: any): Promise<any> {
    let {buildDotNetImageToMapParametersGenerated} = await import('./imageToMapParameters.gb');
    return await buildDotNetImageToMapParametersGenerated(jsObject);
}
