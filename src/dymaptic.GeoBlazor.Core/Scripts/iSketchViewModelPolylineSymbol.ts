
export async function buildJsISketchViewModelPolylineSymbol(dotNetObject: any): Promise<any> {
    let { buildJsISketchViewModelPolylineSymbolGenerated } = await import('./iSketchViewModelPolylineSymbol.gb');
    return await buildJsISketchViewModelPolylineSymbolGenerated(dotNetObject);
}     

export async function buildDotNetISketchViewModelPolylineSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISketchViewModelPolylineSymbolGenerated } = await import('./iSketchViewModelPolylineSymbol.gb');
    return await buildDotNetISketchViewModelPolylineSymbolGenerated(jsObject);
}
