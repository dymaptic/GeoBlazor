export async function buildJsBinaryColorSizeSliderStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBinaryColorSizeSliderStyleGenerated} = await import('./binaryColorSizeSliderStyle.gb');
    return await buildJsBinaryColorSizeSliderStyleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBinaryColorSizeSliderStyle(jsObject: any): Promise<any> {
    let {buildDotNetBinaryColorSizeSliderStyleGenerated} = await import('./binaryColorSizeSliderStyle.gb');
    return await buildDotNetBinaryColorSizeSliderStyleGenerated(jsObject);
}
