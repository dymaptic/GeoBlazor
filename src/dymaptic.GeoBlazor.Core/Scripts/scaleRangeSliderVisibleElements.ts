
export async function buildJsScaleRangeSliderVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsScaleRangeSliderVisibleElementsGenerated } = await import('./scaleRangeSliderVisibleElements.gb');
    return await buildJsScaleRangeSliderVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetScaleRangeSliderVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetScaleRangeSliderVisibleElementsGenerated } = await import('./scaleRangeSliderVisibleElements.gb');
    return await buildDotNetScaleRangeSliderVisibleElementsGenerated(jsObject);
}
