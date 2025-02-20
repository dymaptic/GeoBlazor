export async function buildJsProjectParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsProjectParametersGenerated} = await import('./projectParameters.gb');
    return await buildJsProjectParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetProjectParameters(jsObject: any): Promise<any> {
    let {buildDotNetProjectParametersGenerated} = await import('./projectParameters.gb');
    return await buildDotNetProjectParametersGenerated(jsObject);
}
