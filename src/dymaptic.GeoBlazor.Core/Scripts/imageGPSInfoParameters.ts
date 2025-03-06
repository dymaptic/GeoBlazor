// override generated code in this file

export async function buildJsImageGPSInfoParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageGPSInfoParametersGenerated} = await import('./imageGPSInfoParameters.gb');
    return await buildJsImageGPSInfoParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageGPSInfoParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageGPSInfoParametersGenerated} = await import('./imageGPSInfoParameters.gb');
    return await buildDotNetImageGPSInfoParametersGenerated(jsObject, layerId, viewId);
}
