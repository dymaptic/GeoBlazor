
export async function buildJsIAPIKeyMixin(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIAPIKeyMixinGenerated } = await import('./iAPIKeyMixin.gb');
    return await buildJsIAPIKeyMixinGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIAPIKeyMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIAPIKeyMixinGenerated } = await import('./iAPIKeyMixin.gb');
    return await buildDotNetIAPIKeyMixinGenerated(jsObject, viewId);
}
