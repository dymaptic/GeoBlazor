
export async function buildJsFeatureViewModelFormattedAttributes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureViewModelFormattedAttributesGenerated } = await import('./featureViewModelFormattedAttributes.gb');
    return await buildJsFeatureViewModelFormattedAttributesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureViewModelFormattedAttributes(jsObject: any): Promise<any> {
    let { buildDotNetFeatureViewModelFormattedAttributesGenerated } = await import('./featureViewModelFormattedAttributes.gb');
    return await buildDotNetFeatureViewModelFormattedAttributesGenerated(jsObject);
}
