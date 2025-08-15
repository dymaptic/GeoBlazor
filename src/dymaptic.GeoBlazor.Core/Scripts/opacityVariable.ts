
export async function buildJsOpacityVariable(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildJsOpacityVariableGenerated(dotNetObject, viewId);
}     

export async function buildDotNetOpacityVariable(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOpacityVariableGenerated } = await import('./opacityVariable.gb');
    return await buildDotNetOpacityVariableGenerated(jsObject, viewId);
}
