export async function buildJsSizeSliderStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeSliderStyleGenerated} = await import('./sizeSliderStyle.gb');
    return await buildJsSizeSliderStyleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeSliderStyle(jsObject: any): Promise<any> {
    let {buildDotNetSizeSliderStyleGenerated} = await import('./sizeSliderStyle.gb');
    return await buildDotNetSizeSliderStyleGenerated(jsObject);
}
