
export async function buildJsMarkerSymbolProperties(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMarkerSymbolPropertiesGenerated } = await import('./markerSymbolProperties.gb');
    return await buildJsMarkerSymbolPropertiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMarkerSymbolProperties(jsObject: any): Promise<any> {
    let { buildDotNetMarkerSymbolPropertiesGenerated } = await import('./markerSymbolProperties.gb');
    return await buildDotNetMarkerSymbolPropertiesGenerated(jsObject);
}
