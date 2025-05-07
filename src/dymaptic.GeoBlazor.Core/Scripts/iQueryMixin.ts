
export async function buildJsIQueryMixin(dotNetObject: any): Promise<any> {
    let { buildJsIQueryMixinGenerated } = await import('./iQueryMixin.gb');
    return await buildJsIQueryMixinGenerated(dotNetObject);
}     

export async function buildDotNetIQueryMixin(jsObject: any): Promise<any> {
    let { buildDotNetIQueryMixinGenerated } = await import('./iQueryMixin.gb');
    return await buildDotNetIQueryMixinGenerated(jsObject);
}
