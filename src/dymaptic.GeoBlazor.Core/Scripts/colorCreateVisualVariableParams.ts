
export async function buildJsColorCreateVisualVariableParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorCreateVisualVariableParamsGenerated } = await import('./colorCreateVisualVariableParams.gb');
    return await buildJsColorCreateVisualVariableParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorCreateVisualVariableParams(jsObject: any): Promise<any> {
    let { buildDotNetColorCreateVisualVariableParamsGenerated } = await import('./colorCreateVisualVariableParams.gb');
    return await buildDotNetColorCreateVisualVariableParamsGenerated(jsObject);
}
