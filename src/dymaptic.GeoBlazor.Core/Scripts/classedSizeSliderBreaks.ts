
export async function buildJsClassedSizeSliderBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassedSizeSliderBreaksGenerated } = await import('./classedSizeSliderBreaks.gb');
    return await buildJsClassedSizeSliderBreaksGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClassedSizeSliderBreaks(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetClassedSizeSliderBreaksGenerated } = await import('./classedSizeSliderBreaks.gb');
    return await buildDotNetClassedSizeSliderBreaksGenerated(jsObject, layerId, viewId);
}
