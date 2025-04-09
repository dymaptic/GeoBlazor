
export async function buildJsIQueryMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIQueryMixinGenerated } = await import('./iQueryMixin.gb');
    return await buildJsIQueryMixinGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIQueryMixin(jsObject: any): Promise<any> {
    let { buildDotNetIQueryMixinGenerated } = await import('./iQueryMixin.gb');
    return await buildDotNetIQueryMixinGenerated(jsObject);
}
