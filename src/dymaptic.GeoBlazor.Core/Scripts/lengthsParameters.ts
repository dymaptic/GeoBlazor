export async function buildJsLengthsParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLengthsParametersGenerated } = await import('./lengthsParameters.gb');
    return await buildJsLengthsParametersGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetLengthsParameters(jsObject: any): Promise<any> {
    let { buildDotNetLengthsParametersGenerated } = await import('./lengthsParameters.gb');
    return await buildDotNetLengthsParametersGenerated(jsObject);
}
