
export async function buildJsAttributeTableTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeTableTemplateGenerated } = await import('./attributeTableTemplate.gb');
    return await buildJsAttributeTableTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeTableTemplate(jsObject: any): Promise<any> {
    let { buildDotNetAttributeTableTemplateGenerated } = await import('./attributeTableTemplate.gb');
    return await buildDotNetAttributeTableTemplateGenerated(jsObject);
}
