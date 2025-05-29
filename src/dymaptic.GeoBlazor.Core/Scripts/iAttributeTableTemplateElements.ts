
export async function buildJsIAttributeTableTemplateElements(dotNetObject: any): Promise<any> {
    let { buildJsIAttributeTableTemplateElementsGenerated } = await import('./iAttributeTableTemplateElements.gb');
    return await buildJsIAttributeTableTemplateElementsGenerated(dotNetObject);
}     

export async function buildDotNetIAttributeTableTemplateElements(jsObject: any): Promise<any> {
    let { buildDotNetIAttributeTableTemplateElementsGenerated } = await import('./iAttributeTableTemplateElements.gb');
    return await buildDotNetIAttributeTableTemplateElementsGenerated(jsObject);
}
