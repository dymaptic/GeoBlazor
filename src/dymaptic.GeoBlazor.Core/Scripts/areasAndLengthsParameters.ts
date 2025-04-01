export async function buildJsAreasAndLengthsParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsAreasAndLengthsParametersGenerated} = await import('./areasAndLengthsParameters.gb');
    return await buildJsAreasAndLengthsParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetAreasAndLengthsParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetAreasAndLengthsParametersGenerated} = await import('./areasAndLengthsParameters.gb');
    return await buildDotNetAreasAndLengthsParametersGenerated(jsObject, layerId, viewId);
}
