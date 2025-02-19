// override generated code in this file
export async function buildJsFeatureLayerBaseSaveAsOptions(dotNetObject: any): Promise<any> {
    let { buildJsFeatureLayerBaseSaveAsOptionsGenerated } = await import('./featureLayerBaseSaveAsOptions.gb');
    return await buildJsFeatureLayerBaseSaveAsOptionsGenerated(dotNetObject);
}
export async function buildDotNetFeatureLayerBaseSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerBaseSaveAsOptionsGenerated } = await import('./featureLayerBaseSaveAsOptions.gb');
    return await buildDotNetFeatureLayerBaseSaveAsOptionsGenerated(jsObject);
}
