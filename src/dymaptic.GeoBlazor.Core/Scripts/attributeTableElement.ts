
export async function buildJsAttributeTableElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeTableElementGenerated } = await import('./attributeTableElement.gb');
    return await buildJsAttributeTableElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeTableElement(jsObject: any): Promise<any> {
    let { buildDotNetAttributeTableElementGenerated } = await import('./attributeTableElement.gb');
    return await buildDotNetAttributeTableElementGenerated(jsObject);
}
