
export async function buildJsColorSizeSliderViewModelStopInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorSizeSliderViewModelStopInfoGenerated } = await import('./colorSizeSliderViewModelStopInfo.gb');
    return await buildJsColorSizeSliderViewModelStopInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorSizeSliderViewModelStopInfo(jsObject: any): Promise<any> {
    let { buildDotNetColorSizeSliderViewModelStopInfoGenerated } = await import('./colorSizeSliderViewModelStopInfo.gb');
    return await buildDotNetColorSizeSliderViewModelStopInfoGenerated(jsObject);
}
