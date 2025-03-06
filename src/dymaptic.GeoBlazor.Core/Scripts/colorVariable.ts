
export async function buildJsColorVariable(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildJsColorVariableGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorVariable(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildDotNetColorVariableGenerated(jsObject, layerId, viewId);
}
