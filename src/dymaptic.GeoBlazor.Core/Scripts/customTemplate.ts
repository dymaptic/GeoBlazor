
export async function buildJsCustomTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCustomTemplateGenerated } = await import('./customTemplate.gb');
    return await buildJsCustomTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCustomTemplate(jsObject: any): Promise<any> {
    let { buildDotNetCustomTemplateGenerated } = await import('./customTemplate.gb');
    return await buildDotNetCustomTemplateGenerated(jsObject);
}
