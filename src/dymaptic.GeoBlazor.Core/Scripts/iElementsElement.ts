
export async function buildJsIElementsElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIElementsElementGenerated } = await import('./iElementsElement.gb');
    return await buildJsIElementsElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIElementsElement(jsObject: any): Promise<any> {
    let { buildDotNetIElementsElementGenerated } = await import('./iElementsElement.gb');
    return await buildDotNetIElementsElementGenerated(jsObject);
}
