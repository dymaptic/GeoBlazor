
export async function buildJsIElementsElement(dotNetObject: any): Promise<any> {
    let { buildJsIElementsElementGenerated } = await import('./iElementsElement.gb');
    return await buildJsIElementsElementGenerated(dotNetObject);
}     

export async function buildDotNetIElementsElement(jsObject: any): Promise<any> {
    let { buildDotNetIElementsElementGenerated } = await import('./iElementsElement.gb');
    return await buildDotNetIElementsElementGenerated(jsObject);
}
