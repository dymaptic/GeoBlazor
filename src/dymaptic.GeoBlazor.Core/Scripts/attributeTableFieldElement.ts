
export async function buildJsAttributeTableFieldElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeTableFieldElementGenerated } = await import('./attributeTableFieldElement.gb');
    return await buildJsAttributeTableFieldElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeTableFieldElement(jsObject: any): Promise<any> {
    let { buildDotNetAttributeTableFieldElementGenerated } = await import('./attributeTableFieldElement.gb');
    return await buildDotNetAttributeTableFieldElementGenerated(jsObject);
}
