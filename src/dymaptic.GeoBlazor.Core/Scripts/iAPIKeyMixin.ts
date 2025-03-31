
export async function buildJsIAPIKeyMixin(dotNetObject: any): Promise<any> {
    let { buildJsIAPIKeyMixinGenerated } = await import('./iAPIKeyMixin.gb');
    return await buildJsIAPIKeyMixinGenerated(dotNetObject);
}     

export async function buildDotNetIAPIKeyMixin(jsObject: any): Promise<any> {
    let { buildDotNetIAPIKeyMixinGenerated } = await import('./iAPIKeyMixin.gb');
    return await buildDotNetIAPIKeyMixinGenerated(jsObject);
}
