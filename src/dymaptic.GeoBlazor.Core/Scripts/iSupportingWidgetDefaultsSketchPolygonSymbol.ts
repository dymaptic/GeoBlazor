
export async function buildJsISupportingWidgetDefaultsSketchPolygonSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISupportingWidgetDefaultsSketchPolygonSymbolGenerated } = await import('./iSupportingWidgetDefaultsSketchPolygonSymbol.gb');
    return await buildJsISupportingWidgetDefaultsSketchPolygonSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISupportingWidgetDefaultsSketchPolygonSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISupportingWidgetDefaultsSketchPolygonSymbolGenerated } = await import('./iSupportingWidgetDefaultsSketchPolygonSymbol.gb');
    return await buildDotNetISupportingWidgetDefaultsSketchPolygonSymbolGenerated(jsObject);
}
