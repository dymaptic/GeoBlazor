
export async function buildJsClassedSizeSliderViewModelBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedSizeSliderViewModelBreaksGenerated } = await import('./classedSizeSliderViewModelBreaks.gb');
    return await buildJsClassedSizeSliderViewModelBreaksGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassedSizeSliderViewModelBreaks(jsObject: any): Promise<any> {
    let { buildDotNetClassedSizeSliderViewModelBreaksGenerated } = await import('./classedSizeSliderViewModelBreaks.gb');
    return await buildDotNetClassedSizeSliderViewModelBreaksGenerated(jsObject);
}
