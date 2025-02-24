
export async function buildJsIHighlightLayerViewMixin(dotNetObject: any): Promise<any> {
    let { buildJsIHighlightLayerViewMixinGenerated } = await import('./iHighlightLayerViewMixin.gb');
    return buildJsIHighlightLayerViewMixinGenerated(dotNetObject);
}     

export async function buildDotNetIHighlightLayerViewMixin(jsObject: any): Promise<any> {
    let { buildDotNetIHighlightLayerViewMixinGenerated } = await import('./iHighlightLayerViewMixin.gb');
    return await buildDotNetIHighlightLayerViewMixinGenerated(jsObject);
}
