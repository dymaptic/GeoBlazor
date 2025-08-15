
export async function buildJsIHighlightLayerViewMixin(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIHighlightLayerViewMixinGenerated } = await import('./iHighlightLayerViewMixin.gb');
    return await buildJsIHighlightLayerViewMixinGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIHighlightLayerViewMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIHighlightLayerViewMixinGenerated } = await import('./iHighlightLayerViewMixin.gb');
    return await buildDotNetIHighlightLayerViewMixinGenerated(jsObject, viewId);
}
