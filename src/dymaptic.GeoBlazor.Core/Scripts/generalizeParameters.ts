export async function buildJsGeneralizeParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsGeneralizeParametersGenerated} = await import('./generalizeParameters.gb');
    return await buildJsGeneralizeParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetGeneralizeParameters(jsObject: any): Promise<any> {
    let {buildDotNetGeneralizeParametersGenerated} = await import('./generalizeParameters.gb');
    return await buildDotNetGeneralizeParametersGenerated(jsObject);
}
