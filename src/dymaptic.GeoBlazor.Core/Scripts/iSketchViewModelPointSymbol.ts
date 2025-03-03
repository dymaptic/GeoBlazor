
export async function buildJsISketchViewModelPointSymbol(dotNetObject: any): Promise<any> {
    let { buildJsISketchViewModelPointSymbolGenerated } = await import('./iSketchViewModelPointSymbol.gb');
    return await buildJsISketchViewModelPointSymbolGenerated(dotNetObject);
}     

export async function buildDotNetISketchViewModelPointSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISketchViewModelPointSymbolGenerated } = await import('./iSketchViewModelPointSymbol.gb');
    return await buildDotNetISketchViewModelPointSymbolGenerated(jsObject);
}
