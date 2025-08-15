
export async function buildJsICreationInfoTemplate(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsICreationInfoTemplateGenerated } = await import('./iCreationInfoTemplate.gb');
    return await buildJsICreationInfoTemplateGenerated(dotNetObject, viewId);
}     

export async function buildDotNetICreationInfoTemplate(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetICreationInfoTemplateGenerated } = await import('./iCreationInfoTemplate.gb');
    return await buildDotNetICreationInfoTemplateGenerated(jsObject, viewId);
}
