
export async function buildJsICreateFeaturesWorkflowDataFullTemplate(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsICreateFeaturesWorkflowDataFullTemplateGenerated } = await import('./iCreateFeaturesWorkflowDataFullTemplate.gb');
    return await buildJsICreateFeaturesWorkflowDataFullTemplateGenerated(dotNetObject, viewId);
}     

export async function buildDotNetICreateFeaturesWorkflowDataFullTemplate(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetICreateFeaturesWorkflowDataFullTemplateGenerated } = await import('./iCreateFeaturesWorkflowDataFullTemplate.gb');
    return await buildDotNetICreateFeaturesWorkflowDataFullTemplateGenerated(jsObject, viewId);
}
