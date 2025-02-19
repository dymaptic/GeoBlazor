
export async function buildJsFlowGetSchemeByNameParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFlowGetSchemeByNameParamsGenerated } = await import('./flowGetSchemeByNameParams.gb');
    return await buildJsFlowGetSchemeByNameParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFlowGetSchemeByNameParams(jsObject: any): Promise<any> {
    let { buildDotNetFlowGetSchemeByNameParamsGenerated } = await import('./flowGetSchemeByNameParams.gb');
    return await buildDotNetFlowGetSchemeByNameParamsGenerated(jsObject);
}
