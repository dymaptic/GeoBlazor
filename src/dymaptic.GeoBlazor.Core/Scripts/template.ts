
export async function buildJsTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTemplateGenerated } = await import('./template.gb');
    return await buildJsTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTemplate(jsObject: any): Promise<any> {
    let { buildDotNetTemplateGenerated } = await import('./template.gb');
    return await buildDotNetTemplateGenerated(jsObject);
}
