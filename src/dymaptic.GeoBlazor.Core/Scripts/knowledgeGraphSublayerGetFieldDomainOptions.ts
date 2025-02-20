export async function buildJsKnowledgeGraphSublayerGetFieldDomainOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsKnowledgeGraphSublayerGetFieldDomainOptionsGenerated} = await import('./knowledgeGraphSublayerGetFieldDomainOptions.gb');
    return await buildJsKnowledgeGraphSublayerGetFieldDomainOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetKnowledgeGraphSublayerGetFieldDomainOptions(jsObject: any): Promise<any> {
    let {buildDotNetKnowledgeGraphSublayerGetFieldDomainOptionsGenerated} = await import('./knowledgeGraphSublayerGetFieldDomainOptions.gb');
    return await buildDotNetKnowledgeGraphSublayerGetFieldDomainOptionsGenerated(jsObject);
}
