
export async function buildJsICustomParametersMixin(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsICustomParametersMixinGenerated } = await import('./iCustomParametersMixin.gb');
    return await buildJsICustomParametersMixinGenerated(dotNetObject, viewId);
}     

export async function buildDotNetICustomParametersMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetICustomParametersMixinGenerated } = await import('./iCustomParametersMixin.gb');
    return await buildDotNetICustomParametersMixinGenerated(jsObject, viewId);
}
