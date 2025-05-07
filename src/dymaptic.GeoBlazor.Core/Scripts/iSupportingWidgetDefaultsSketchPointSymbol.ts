
export async function buildJsISupportingWidgetDefaultsSketchPointSymbol(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsISupportingWidgetDefaultsSketchPointSymbolGenerated } = await import('./iSupportingWidgetDefaultsSketchPointSymbol.gb');
    return await buildJsISupportingWidgetDefaultsSketchPointSymbolGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetISupportingWidgetDefaultsSketchPointSymbol(jsObject: any): Promise<any> {
    let { buildDotNetISupportingWidgetDefaultsSketchPointSymbolGenerated } = await import('./iSupportingWidgetDefaultsSketchPointSymbol.gb');
    return await buildDotNetISupportingWidgetDefaultsSketchPointSymbolGenerated(jsObject);
}
