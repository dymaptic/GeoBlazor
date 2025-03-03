
export async function buildJsIProfileVariable(dotNetObject: any): Promise<any> {
    let { buildJsIProfileVariableGenerated } = await import('./iProfileVariable.gb');
    return await buildJsIProfileVariableGenerated(dotNetObject);
}     

export async function buildDotNetIProfileVariable(jsObject: any): Promise<any> {
    let { buildDotNetIProfileVariableGenerated } = await import('./iProfileVariable.gb');
    return await buildDotNetIProfileVariableGenerated(jsObject);
}
