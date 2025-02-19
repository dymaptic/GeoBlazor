export async function buildJsFlowGetSchemesByTagParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFlowGetSchemesByTagParamsGenerated } = await import('./flowGetSchemesByTagParams.gb');
    return await buildJsFlowGetSchemesByTagParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFlowGetSchemesByTagParams(jsObject: any): Promise<any> {
    let { buildDotNetFlowGetSchemesByTagParamsGenerated } = await import('./flowGetSchemesByTagParams.gb');
    return await buildDotNetFlowGetSchemesByTagParamsGenerated(jsObject);
}
