export async function buildJsOpacitySliderViewModelStopInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsOpacitySliderViewModelStopInfoGenerated} = await import('./opacitySliderViewModelStopInfo.gb');
    return await buildJsOpacitySliderViewModelStopInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetOpacitySliderViewModelStopInfo(jsObject: any): Promise<any> {
    let {buildDotNetOpacitySliderViewModelStopInfoGenerated} = await import('./opacitySliderViewModelStopInfo.gb');
    return await buildDotNetOpacitySliderViewModelStopInfoGenerated(jsObject);
}
