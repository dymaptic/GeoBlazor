export async function buildJsSymbolUtilsGetDisplayedSymbolOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbolUtilsGetDisplayedSymbolOptionsGenerated} = await import('./symbolUtilsGetDisplayedSymbolOptions.gb');
    return await buildJsSymbolUtilsGetDisplayedSymbolOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbolUtilsGetDisplayedSymbolOptions(jsObject: any): Promise<any> {
    let {buildDotNetSymbolUtilsGetDisplayedSymbolOptionsGenerated} = await import('./symbolUtilsGetDisplayedSymbolOptions.gb');
    return await buildDotNetSymbolUtilsGetDisplayedSymbolOptionsGenerated(jsObject);
}
