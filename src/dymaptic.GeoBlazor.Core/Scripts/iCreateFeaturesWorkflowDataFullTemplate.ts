
export async function buildJsICreateFeaturesWorkflowDataFullTemplate(dotNetObject: any): Promise<any> {
    let { buildJsICreateFeaturesWorkflowDataFullTemplateGenerated } = await import('./iCreateFeaturesWorkflowDataFullTemplate.gb');
    return await buildJsICreateFeaturesWorkflowDataFullTemplateGenerated(dotNetObject);
}     

export async function buildDotNetICreateFeaturesWorkflowDataFullTemplate(jsObject: any): Promise<any> {
    let { buildDotNetICreateFeaturesWorkflowDataFullTemplateGenerated } = await import('./iCreateFeaturesWorkflowDataFullTemplate.gb');
    return await buildDotNetICreateFeaturesWorkflowDataFullTemplateGenerated(jsObject);
}
