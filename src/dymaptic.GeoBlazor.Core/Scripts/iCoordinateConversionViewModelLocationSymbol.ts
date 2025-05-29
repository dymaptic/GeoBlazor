
export async function buildJsICoordinateConversionViewModelLocationSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsICoordinateConversionViewModelLocationSymbolGenerated } = await import('./iCoordinateConversionViewModelLocationSymbol.gb');
    return await buildJsICoordinateConversionViewModelLocationSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetICoordinateConversionViewModelLocationSymbol(jsObject: any): Promise<any> {
    let { buildDotNetICoordinateConversionViewModelLocationSymbolGenerated } = await import('./iCoordinateConversionViewModelLocationSymbol.gb');
    return await buildDotNetICoordinateConversionViewModelLocationSymbolGenerated(jsObject);
}
