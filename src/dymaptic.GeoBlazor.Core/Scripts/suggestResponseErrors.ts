
export async function buildJsSuggestResponseErrors(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSuggestResponseErrorsGenerated } = await import('./suggestResponseErrors.gb');
    return await buildJsSuggestResponseErrorsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSuggestResponseErrors(jsObject: any): Promise<any> {
    let { buildDotNetSuggestResponseErrorsGenerated } = await import('./suggestResponseErrors.gb');
    return await buildDotNetSuggestResponseErrorsGenerated(jsObject);
}
