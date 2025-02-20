export async function buildJsTraceParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTraceParametersGenerated} = await import('./traceParameters.gb');
    return await buildJsTraceParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTraceParameters(jsObject: any): Promise<any> {
    let {buildDotNetTraceParametersGenerated} = await import('./traceParameters.gb');
    return await buildDotNetTraceParametersGenerated(jsObject);
}
