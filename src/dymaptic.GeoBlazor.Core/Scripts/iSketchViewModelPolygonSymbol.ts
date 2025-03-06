
export async function buildJsISketchViewModelPolygonSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISketchViewModelPolygonSymbolGenerated } = await import('./iSketchViewModelPolygonSymbol.gb');
    return await buildJsISketchViewModelPolygonSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISketchViewModelPolygonSymbol(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetISketchViewModelPolygonSymbolGenerated } = await import('./iSketchViewModelPolygonSymbol.gb');
    return await buildDotNetISketchViewModelPolygonSymbolGenerated(jsObject, layerId, viewId);
}
