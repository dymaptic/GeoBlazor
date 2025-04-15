
export async function buildJsICreationInfoTemplate(dotNetObject: any): Promise<any> {
    let { buildJsICreationInfoTemplateGenerated } = await import('./iCreationInfoTemplate.gb');
    return await buildJsICreationInfoTemplateGenerated(dotNetObject);
}     

export async function buildDotNetICreationInfoTemplate(jsObject: any): Promise<any> {
    let { buildDotNetICreationInfoTemplateGenerated } = await import('./iCreationInfoTemplate.gb');
    return await buildDotNetICreationInfoTemplateGenerated(jsObject);
}
