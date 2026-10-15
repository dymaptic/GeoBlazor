
export async function buildJsFeatureLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerSaveAsOptionsGenerated } = await import('./featureLayerSaveAsOptions.gb');
    return await buildJsFeatureLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerSaveAsOptionsGenerated } = await import('./featureLayerSaveAsOptions.gb');
    return await buildDotNetFeatureLayerSaveAsOptionsGenerated(jsObject);
}
