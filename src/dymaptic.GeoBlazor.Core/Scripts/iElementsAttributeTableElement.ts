
export async function buildJsIElementsAttributeTableElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIElementsAttributeTableElementGenerated } = await import('./iElementsAttributeTableElement.gb');
    return await buildJsIElementsAttributeTableElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIElementsAttributeTableElement(jsObject: any): Promise<any> {
    let { buildDotNetIElementsAttributeTableElementGenerated } = await import('./iElementsAttributeTableElement.gb');
    return await buildDotNetIElementsAttributeTableElementGenerated(jsObject);
}
