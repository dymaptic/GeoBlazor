
export async function buildJsIFeatureLayerViewMixin(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return await buildJsIFeatureLayerViewMixinGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureLayerViewMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return await buildDotNetIFeatureLayerViewMixinGenerated(jsObject, viewId);
}
