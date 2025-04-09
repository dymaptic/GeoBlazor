
export async function buildJsITemplateItemTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsITemplateItemTemplateGenerated } = await import('./iTemplateItemTemplate.gb');
    return await buildJsITemplateItemTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetITemplateItemTemplate(jsObject: any): Promise<any> {
    let { buildDotNetITemplateItemTemplateGenerated } = await import('./iTemplateItemTemplate.gb');
    return await buildDotNetITemplateItemTemplateGenerated(jsObject);
}
