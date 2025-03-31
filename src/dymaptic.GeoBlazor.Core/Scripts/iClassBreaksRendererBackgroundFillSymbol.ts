
export async function buildJsIClassBreaksRendererBackgroundFillSymbol(dotNetObject: any): Promise<any> {
    let { buildJsIClassBreaksRendererBackgroundFillSymbolGenerated } = await import('./iClassBreaksRendererBackgroundFillSymbol.gb');
    return await buildJsIClassBreaksRendererBackgroundFillSymbolGenerated(dotNetObject);
}     

export async function buildDotNetIClassBreaksRendererBackgroundFillSymbol(jsObject: any): Promise<any> {
    let { buildDotNetIClassBreaksRendererBackgroundFillSymbolGenerated } = await import('./iClassBreaksRendererBackgroundFillSymbol.gb');
    return await buildDotNetIClassBreaksRendererBackgroundFillSymbolGenerated(jsObject);
}
