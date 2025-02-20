export async function buildJsClassedColorSliderBreaks(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsClassedColorSliderBreaksGenerated} = await import('./classedColorSliderBreaks.gb');
    return await buildJsClassedColorSliderBreaksGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetClassedColorSliderBreaks(jsObject: any): Promise<any> {
    let {buildDotNetClassedColorSliderBreaksGenerated} = await import('./classedColorSliderBreaks.gb');
    return await buildDotNetClassedColorSliderBreaksGenerated(jsObject);
}
