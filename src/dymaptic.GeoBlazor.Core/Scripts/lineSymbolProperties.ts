
export async function buildJsLineSymbolProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineSymbolPropertiesGenerated } = await import('./lineSymbolProperties.gb');
    return await buildJsLineSymbolPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineSymbolProperties(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLineSymbolPropertiesGenerated } = await import('./lineSymbolProperties.gb');
    return await buildDotNetLineSymbolPropertiesGenerated(jsObject, viewId);
}
