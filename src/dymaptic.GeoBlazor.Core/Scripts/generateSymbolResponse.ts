export async function buildJsGenerateSymbolResponse(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGenerateSymbolResponseGenerated } = await import('./generateSymbolResponse.gb');
    return await buildJsGenerateSymbolResponseGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetGenerateSymbolResponse(jsObject: any): Promise<any> {
    let { buildDotNetGenerateSymbolResponseGenerated } = await import('./generateSymbolResponse.gb');
    return await buildDotNetGenerateSymbolResponseGenerated(jsObject);
}
