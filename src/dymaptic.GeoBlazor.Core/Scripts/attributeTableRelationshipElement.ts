
export async function buildJsAttributeTableRelationshipElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeTableRelationshipElementGenerated } = await import('./attributeTableRelationshipElement.gb');
    return await buildJsAttributeTableRelationshipElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeTableRelationshipElement(jsObject: any): Promise<any> {
    let { buildDotNetAttributeTableRelationshipElementGenerated } = await import('./attributeTableRelationshipElement.gb');
    return await buildDotNetAttributeTableRelationshipElementGenerated(jsObject);
}
