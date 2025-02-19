export async function buildJsOpacitySliderStyle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacitySliderStyleGenerated } = await import('./opacitySliderStyle.gb');
    return await buildJsOpacitySliderStyleGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetOpacitySliderStyle(jsObject: any): Promise<any> {
    let { buildDotNetOpacitySliderStyleGenerated } = await import('./opacitySliderStyle.gb');
    return await buildDotNetOpacitySliderStyleGenerated(jsObject);
}
