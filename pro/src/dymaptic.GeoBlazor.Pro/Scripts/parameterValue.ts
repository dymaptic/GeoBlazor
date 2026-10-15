
export async function buildJsParameterValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsParameterValueGenerated } = await import('./parameterValue.gb');
    return await buildJsParameterValueGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetParameterValue(jsObject: any): Promise<any> {
    let { buildDotNetParameterValueGenerated } = await import('./parameterValue.gb');
    return await buildDotNetParameterValueGenerated(jsObject);
}
