
export async function buildJsOpacityVariable(dotNetObject: any): Promise<any> {
    let { buildJsOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildJsOpacityVariableGenerated(dotNetObject);
}     

export async function buildDotNetOpacityVariable(jsObject: any): Promise<any> {
    let { buildDotNetOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildDotNetOpacityVariableGenerated(jsObject);
}
