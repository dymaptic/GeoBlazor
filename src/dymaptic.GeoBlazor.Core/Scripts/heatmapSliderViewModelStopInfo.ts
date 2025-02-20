export async function buildJsHeatmapSliderViewModelStopInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHeatmapSliderViewModelStopInfoGenerated} = await import('./heatmapSliderViewModelStopInfo.gb');
    return await buildJsHeatmapSliderViewModelStopInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHeatmapSliderViewModelStopInfo(jsObject: any): Promise<any> {
    let {buildDotNetHeatmapSliderViewModelStopInfoGenerated} = await import('./heatmapSliderViewModelStopInfo.gb');
    return await buildDotNetHeatmapSliderViewModelStopInfoGenerated(jsObject);
}
