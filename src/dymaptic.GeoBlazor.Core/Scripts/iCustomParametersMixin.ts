
export async function buildJsICustomParametersMixin(dotNetObject: any): Promise<any> {
    let { buildJsICustomParametersMixinGenerated } = await import('./iCustomParametersMixin.gb');
    return await buildJsICustomParametersMixinGenerated(dotNetObject);
}     

export async function buildDotNetICustomParametersMixin(jsObject: any): Promise<any> {
    let { buildDotNetICustomParametersMixinGenerated } = await import('./iCustomParametersMixin.gb');
    return await buildDotNetICustomParametersMixinGenerated(jsObject);
}
