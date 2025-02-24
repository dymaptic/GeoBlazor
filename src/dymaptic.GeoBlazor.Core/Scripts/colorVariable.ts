
export async function buildJsColorVariable(dotNetObject: any): Promise<any> {
    let { buildJsColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildJsColorVariableGenerated(dotNetObject);
}     

export async function buildDotNetColorVariable(jsObject: any): Promise<any> {
    let { buildDotNetColorVariableGenerated } = await import('./colorVariable.gb');
    return await buildDotNetColorVariableGenerated(jsObject);
}
