
export async function buildJsSymbolTableElementInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSymbolTableElementInfoGenerated } = await import('./symbolTableElementInfo.gb');
    return await buildJsSymbolTableElementInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSymbolTableElementInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSymbolTableElementInfoGenerated } = await import('./symbolTableElementInfo.gb');
    return await buildDotNetSymbolTableElementInfoGenerated(jsObject, layerId, viewId);
}
