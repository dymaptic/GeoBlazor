
export async function buildJsITemplateItemTemplate(dotNetObject: any): Promise<any> {
    let { buildJsITemplateItemTemplateGenerated } = await import('./iTemplateItemTemplate.gb');
    return await buildJsITemplateItemTemplateGenerated(dotNetObject);
}     

export async function buildDotNetITemplateItemTemplate(jsObject: any): Promise<any> {
    let { buildDotNetITemplateItemTemplateGenerated } = await import('./iTemplateItemTemplate.gb');
    return await buildDotNetITemplateItemTemplateGenerated(jsObject);
}
