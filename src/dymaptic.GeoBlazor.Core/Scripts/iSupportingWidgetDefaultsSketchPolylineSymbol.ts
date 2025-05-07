
export async function buildJsISupportingWidgetDefaultsSketchPolylineSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISupportingWidgetDefaultsSketchPolylineSymbolGenerated } = await import('./iSupportingWidgetDefaultsSketchPolylineSymbol.gb');
    return await buildJsISupportingWidgetDefaultsSketchPolylineSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISupportingWidgetDefaultsSketchPolylineSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISupportingWidgetDefaultsSketchPolylineSymbolGenerated } = await import('./iSupportingWidgetDefaultsSketchPolylineSymbol.gb');
    return await buildDotNetISupportingWidgetDefaultsSketchPolylineSymbolGenerated(jsObject);
}
