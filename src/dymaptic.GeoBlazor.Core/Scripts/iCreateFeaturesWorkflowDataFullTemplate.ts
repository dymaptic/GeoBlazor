
export async function buildJsICreateFeaturesWorkflowDataFullTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsICreateFeaturesWorkflowDataFullTemplateGenerated } = await import('./iCreateFeaturesWorkflowDataFullTemplate.gb');
    return await buildJsICreateFeaturesWorkflowDataFullTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetICreateFeaturesWorkflowDataFullTemplate(jsObject: any): Promise<any> {
    let { buildDotNetICreateFeaturesWorkflowDataFullTemplateGenerated } = await import('./iCreateFeaturesWorkflowDataFullTemplate.gb');
    return await buildDotNetICreateFeaturesWorkflowDataFullTemplateGenerated(jsObject);
}
