export async function buildJsFlowGetSchemesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFlowGetSchemesParamsGenerated} = await import('./flowGetSchemesParams.gb');
    return await buildJsFlowGetSchemesParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFlowGetSchemesParams(jsObject: any): Promise<any> {
    let {buildDotNetFlowGetSchemesParamsGenerated} = await import('./flowGetSchemesParams.gb');
    return await buildDotNetFlowGetSchemesParamsGenerated(jsObject);
}
