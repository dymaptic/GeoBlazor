
export async function buildJsTableTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTableTemplateGenerated } = await import('./tableTemplate.gb');
    return await buildJsTableTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTableTemplate(jsObject: any): Promise<any> {
    let { buildDotNetTableTemplateGenerated } = await import('./tableTemplate.gb');
    return await buildDotNetTableTemplateGenerated(jsObject);
}
