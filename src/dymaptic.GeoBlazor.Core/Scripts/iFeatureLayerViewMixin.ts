
export async function buildJsIFeatureLayerViewMixin(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return buildJsIFeatureLayerViewMixinGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureLayerViewMixin(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureLayerViewMixinGenerated } = await import('./iFeatureLayerViewMixin.gb');
    return await buildDotNetIFeatureLayerViewMixinGenerated(jsObject);
}
