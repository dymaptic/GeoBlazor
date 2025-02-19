export async function buildJsClassedColorSliderViewModelBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedColorSliderViewModelBreaksGenerated } = await import('./classedColorSliderViewModelBreaks.gb');
    return await buildJsClassedColorSliderViewModelBreaksGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetClassedColorSliderViewModelBreaks(jsObject: any): Promise<any> {
    let { buildDotNetClassedColorSliderViewModelBreaksGenerated } = await import('./classedColorSliderViewModelBreaks.gb');
    return await buildDotNetClassedColorSliderViewModelBreaksGenerated(jsObject);
}
