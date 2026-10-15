
export async function buildJsIProfileVariable(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIProfileVariableGenerated } = await import('./iProfileVariable.gb');
    return await buildJsIProfileVariableGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIProfileVariable(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIProfileVariableGenerated } = await import('./iProfileVariable.gb');
    return await buildDotNetIProfileVariableGenerated(jsObject, viewId);
}
