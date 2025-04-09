
export async function buildJsICreationInfoTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsICreationInfoTemplateGenerated } = await import('./iCreationInfoTemplate.gb');
    return await buildJsICreationInfoTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetICreationInfoTemplate(jsObject: any): Promise<any> {
    let { buildDotNetICreationInfoTemplateGenerated } = await import('./iCreationInfoTemplate.gb');
    return await buildDotNetICreationInfoTemplateGenerated(jsObject);
}
