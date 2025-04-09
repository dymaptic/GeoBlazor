
export async function buildJsAttributeTableGroupElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeTableGroupElementGenerated } = await import('./attributeTableGroupElement.gb');
    return await buildJsAttributeTableGroupElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeTableGroupElement(jsObject: any): Promise<any> {
    let { buildDotNetAttributeTableGroupElementGenerated } = await import('./attributeTableGroupElement.gb');
    return await buildDotNetAttributeTableGroupElementGenerated(jsObject);
}
