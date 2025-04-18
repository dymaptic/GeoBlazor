
export async function buildJsIElementsAttributeTableElement(dotNetObject: any): Promise<any> {
    let { buildJsIElementsAttributeTableElementGenerated } = await import('./iElementsAttributeTableElement.gb');
    return await buildJsIElementsAttributeTableElementGenerated(dotNetObject);
}     

export async function buildDotNetIElementsAttributeTableElement(jsObject: any): Promise<any> {
    let { buildDotNetIElementsAttributeTableElementGenerated } = await import('./iElementsAttributeTableElement.gb');
    return await buildDotNetIElementsAttributeTableElementGenerated(jsObject);
}
