export async function buildJsSymbolTableElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSymbolTableElementGenerated} = await import('./symbolTableElement.gb');
    return await buildJsSymbolTableElementGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSymbolTableElement(jsObject: any): Promise<any> {
    let {buildDotNetSymbolTableElementGenerated} = await import('./symbolTableElement.gb');
    return await buildDotNetSymbolTableElementGenerated(jsObject);
}
