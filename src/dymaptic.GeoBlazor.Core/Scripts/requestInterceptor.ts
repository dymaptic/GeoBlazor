
export async function buildJsRequestInterceptor(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRequestInterceptorGenerated } = await import('./requestInterceptor.gb');
    return await buildJsRequestInterceptorGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRequestInterceptor(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetRequestInterceptorGenerated } = await import('./requestInterceptor.gb');
    return await buildDotNetRequestInterceptorGenerated(jsObject, layerId, viewId);
}
