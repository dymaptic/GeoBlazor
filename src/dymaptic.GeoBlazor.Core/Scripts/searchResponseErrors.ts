
export async function buildJsSearchResponseErrors(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchResponseErrorsGenerated } = await import('./searchResponseErrors.gb');
    return await buildJsSearchResponseErrorsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchResponseErrors(jsObject: any): Promise<any> {
    let { buildDotNetSearchResponseErrorsGenerated } = await import('./searchResponseErrors.gb');
    return await buildDotNetSearchResponseErrorsGenerated(jsObject);
}
