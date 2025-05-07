
export async function buildJsSearchViewModelSearchResponseErrors(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchViewModelSearchResponseErrorsGenerated } = await import('./searchViewModelSearchResponseErrors.gb');
    return await buildJsSearchViewModelSearchResponseErrorsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchViewModelSearchResponseErrors(jsObject: any): Promise<any> {
    let { buildDotNetSearchViewModelSearchResponseErrorsGenerated } = await import('./searchViewModelSearchResponseErrors.gb');
    return await buildDotNetSearchViewModelSearchResponseErrorsGenerated(jsObject);
}
