export async function buildJsSearchViewModelDefaultSymbols(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSearchViewModelDefaultSymbolsGenerated} = await import('./searchViewModelDefaultSymbols.gb');
    return await buildJsSearchViewModelDefaultSymbolsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSearchViewModelDefaultSymbols(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetSearchViewModelDefaultSymbolsGenerated} = await import('./searchViewModelDefaultSymbols.gb');
    return await buildDotNetSearchViewModelDefaultSymbolsGenerated(jsObject, viewId);
}
