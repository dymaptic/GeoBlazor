
export async function buildJsISymbol2D(dotNetObject: any): Promise<any> {
    let { buildJsISymbol2DGenerated } = await import('./iSymbol2D.gb');
    return await buildJsISymbol2DGenerated(dotNetObject);
}     

export async function buildDotNetISymbol2D(jsObject: any): Promise<any> {
    let { buildDotNetISymbol2DGenerated } = await import('./iSymbol2D.gb');
    return await buildDotNetISymbol2DGenerated(jsObject);
}
