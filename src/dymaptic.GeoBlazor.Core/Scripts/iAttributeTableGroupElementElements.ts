
export async function buildJsIAttributeTableGroupElementElements(dotNetObject: any): Promise<any> {
    let { buildJsIAttributeTableGroupElementElementsGenerated } = await import('./iAttributeTableGroupElementElements.gb');
    return await buildJsIAttributeTableGroupElementElementsGenerated(dotNetObject);
}     

export async function buildDotNetIAttributeTableGroupElementElements(jsObject: any): Promise<any> {
    let { buildDotNetIAttributeTableGroupElementElementsGenerated } = await import('./iAttributeTableGroupElementElements.gb');
    return await buildDotNetIAttributeTableGroupElementElementsGenerated(jsObject);
}
