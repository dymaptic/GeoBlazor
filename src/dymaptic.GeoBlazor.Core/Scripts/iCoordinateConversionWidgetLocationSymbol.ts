
export async function buildJsICoordinateConversionWidgetLocationSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsICoordinateConversionWidgetLocationSymbolGenerated } = await import('./iCoordinateConversionWidgetLocationSymbol.gb');
    return await buildJsICoordinateConversionWidgetLocationSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetICoordinateConversionWidgetLocationSymbol(jsObject: any): Promise<any> {
    let { buildDotNetICoordinateConversionWidgetLocationSymbolGenerated } = await import('./iCoordinateConversionWidgetLocationSymbol.gb');
    return await buildDotNetICoordinateConversionWidgetLocationSymbolGenerated(jsObject);
}
