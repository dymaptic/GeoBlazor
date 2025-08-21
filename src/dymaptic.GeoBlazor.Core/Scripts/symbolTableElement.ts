
export async function buildJsSymbolTableElement(dotNetObject: any): Promise<any> {
    let { buildJsSymbolTableElementGenerated } = await import('./symbolTableElement.gb');
    return await buildJsSymbolTableElementGenerated(dotNetObject);
}     

export async function buildDotNetSymbolTableElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSymbolTableElementGenerated } = await import('./symbolTableElement.gb');
    return await buildDotNetSymbolTableElementGenerated(jsObject, viewId);
}
