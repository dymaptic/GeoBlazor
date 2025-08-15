
export async function buildJsITemplateItemTemplate(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsITemplateItemTemplateGenerated } = await import('./iTemplateItemTemplate.gb');
    return await buildJsITemplateItemTemplateGenerated(dotNetObject, viewId);
}     

export async function buildDotNetITemplateItemTemplate(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetITemplateItemTemplateGenerated } = await import('./iTemplateItemTemplate.gb');
    return await buildDotNetITemplateItemTemplateGenerated(jsObject, viewId);
}
