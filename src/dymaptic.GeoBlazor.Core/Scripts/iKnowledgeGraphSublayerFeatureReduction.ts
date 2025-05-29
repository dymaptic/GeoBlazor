
export async function buildJsIKnowledgeGraphSublayerFeatureReduction(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIKnowledgeGraphSublayerFeatureReductionGenerated } = await import('./iKnowledgeGraphSublayerFeatureReduction.gb');
    return await buildJsIKnowledgeGraphSublayerFeatureReductionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIKnowledgeGraphSublayerFeatureReduction(jsObject: any): Promise<any> {
    let { buildDotNetIKnowledgeGraphSublayerFeatureReductionGenerated } = await import('./iKnowledgeGraphSublayerFeatureReduction.gb');
    return await buildDotNetIKnowledgeGraphSublayerFeatureReductionGenerated(jsObject);
}
