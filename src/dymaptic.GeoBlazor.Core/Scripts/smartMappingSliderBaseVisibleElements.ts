
export async function buildJsSmartMappingSliderBaseVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSmartMappingSliderBaseVisibleElementsGenerated } = await import('./smartMappingSliderBaseVisibleElements.gb');
    return await buildJsSmartMappingSliderBaseVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSmartMappingSliderBaseVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetSmartMappingSliderBaseVisibleElementsGenerated } = await import('./smartMappingSliderBaseVisibleElements.gb');
    return await buildDotNetSmartMappingSliderBaseVisibleElementsGenerated(jsObject);
}
