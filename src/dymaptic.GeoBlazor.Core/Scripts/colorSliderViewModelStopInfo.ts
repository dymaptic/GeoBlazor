export async function buildJsColorSliderViewModelStopInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSliderViewModelStopInfoGenerated} = await import('./colorSliderViewModelStopInfo.gb');
    return await buildJsColorSliderViewModelStopInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSliderViewModelStopInfo(jsObject: any): Promise<any> {
    let {buildDotNetColorSliderViewModelStopInfoGenerated} = await import('./colorSliderViewModelStopInfo.gb');
    return await buildDotNetColorSliderViewModelStopInfoGenerated(jsObject);
}
