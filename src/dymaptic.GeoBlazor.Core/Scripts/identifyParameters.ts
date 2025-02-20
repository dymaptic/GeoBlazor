export async function buildJsIdentifyParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIdentifyParametersGenerated} = await import('./identifyParameters.gb');
    return await buildJsIdentifyParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIdentifyParameters(jsObject: any): Promise<any> {
    let {buildDotNetIdentifyParametersGenerated} = await import('./identifyParameters.gb');
    return await buildDotNetIdentifyParametersGenerated(jsObject);
}
