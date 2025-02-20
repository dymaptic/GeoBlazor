export async function buildJsClassedSizeSliderStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClassedSizeSliderStyleGenerated} = await import('./classedSizeSliderStyle.gb');
    return await buildJsClassedSizeSliderStyleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClassedSizeSliderStyle(jsObject: any): Promise<any> {
    let {buildDotNetClassedSizeSliderStyleGenerated} = await import('./classedSizeSliderStyle.gb');
    return await buildDotNetClassedSizeSliderStyleGenerated(jsObject);
}
