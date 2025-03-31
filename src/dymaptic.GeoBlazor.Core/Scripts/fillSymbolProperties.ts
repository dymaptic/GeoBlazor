
export async function buildJsFillSymbolProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFillSymbolPropertiesGenerated } = await import('./fillSymbolProperties.gb');
    return await buildJsFillSymbolPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFillSymbolProperties(jsObject: any): Promise<any> {
    let { buildDotNetFillSymbolPropertiesGenerated } = await import('./fillSymbolProperties.gb');
    return await buildDotNetFillSymbolPropertiesGenerated(jsObject);
}
