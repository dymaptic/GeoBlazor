
export async function buildJsConnectionParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConnectionParametersGenerated } = await import('./connectionParameters.gb');
    return await buildJsConnectionParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConnectionParameters(jsObject: any): Promise<any> {
    let { buildDotNetConnectionParametersGenerated } = await import('./connectionParameters.gb');
    return await buildDotNetConnectionParametersGenerated(jsObject);
}
