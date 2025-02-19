
export async function buildJsFeatureTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTemplateGenerated } = await import('./featureTemplate.gb');
    return await buildJsFeatureTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTemplate(jsObject: any): Promise<any> {
    let { buildDotNetFeatureTemplateGenerated } = await import('./featureTemplate.gb');
    return await buildDotNetFeatureTemplateGenerated(jsObject);
}
