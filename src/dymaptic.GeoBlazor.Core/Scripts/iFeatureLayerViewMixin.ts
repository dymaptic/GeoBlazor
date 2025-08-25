
export async function buildJsIFeatureLayerViewMixin(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return await buildJsIFeatureLayerViewMixinGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIFeatureLayerViewMixin(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return await buildDotNetIFeatureLayerViewMixinGenerated(jsObject, viewId);
}
