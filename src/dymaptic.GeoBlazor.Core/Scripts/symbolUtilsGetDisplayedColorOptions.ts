
export async function buildJsSymbolUtilsGetDisplayedColorOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolUtilsGetDisplayedColorOptionsGenerated } = await import('./symbolUtilsGetDisplayedColorOptions.gb');
    return await buildJsSymbolUtilsGetDisplayedColorOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbolUtilsGetDisplayedColorOptions(jsObject: any): Promise<any> {
    let { buildDotNetSymbolUtilsGetDisplayedColorOptionsGenerated } = await import('./symbolUtilsGetDisplayedColorOptions.gb');
    return await buildDotNetSymbolUtilsGetDisplayedColorOptionsGenerated(jsObject);
}
