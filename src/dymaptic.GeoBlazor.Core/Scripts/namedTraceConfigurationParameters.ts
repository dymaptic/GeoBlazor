
export async function buildJsNamedTraceConfigurationParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsNamedTraceConfigurationParametersGenerated } = await import('./namedTraceConfigurationParameters.gb');
    return await buildJsNamedTraceConfigurationParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetNamedTraceConfigurationParameters(jsObject: any): Promise<any> {
    let { buildDotNetNamedTraceConfigurationParametersGenerated } = await import('./namedTraceConfigurationParameters.gb');
    return await buildDotNetNamedTraceConfigurationParametersGenerated(jsObject);
}
