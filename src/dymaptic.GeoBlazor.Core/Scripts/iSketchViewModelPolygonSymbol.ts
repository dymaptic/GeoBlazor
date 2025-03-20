
export async function buildJsISketchViewModelPolygonSymbol(dotNetObject: any): Promise<any> {
    let { buildJsISketchViewModelPolygonSymbolGenerated } = await import('./iSketchViewModelPolygonSymbol.gb');
    return await buildJsISketchViewModelPolygonSymbolGenerated(dotNetObject);
}     

export async function buildDotNetISketchViewModelPolygonSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISketchViewModelPolygonSymbolGenerated } = await import('./iSketchViewModelPolygonSymbol.gb');
    return await buildDotNetISketchViewModelPolygonSymbolGenerated(jsObject);
}
