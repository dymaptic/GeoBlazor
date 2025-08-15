
export async function buildJsColorVariable(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildJsColorVariableGenerated(dotNetObject, viewId);
}     

export async function buildDotNetColorVariable(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildDotNetColorVariableGenerated(jsObject, viewId);
}
