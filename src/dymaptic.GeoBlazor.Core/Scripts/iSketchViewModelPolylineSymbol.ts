
export async function buildJsISketchViewModelPolylineSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISketchViewModelPolylineSymbolGenerated } = await import('./iSketchViewModelPolylineSymbol.gb');
    return await buildJsISketchViewModelPolylineSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISketchViewModelPolylineSymbol(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetISketchViewModelPolylineSymbolGenerated } = await import('./iSketchViewModelPolylineSymbol.gb');
    return await buildDotNetISketchViewModelPolylineSymbolGenerated(jsObject, layerId, viewId);
}
