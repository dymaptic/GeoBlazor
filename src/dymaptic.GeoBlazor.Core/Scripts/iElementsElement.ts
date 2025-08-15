
export async function buildJsIElementsElement(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIElementsElementGenerated } = await import('./iElementsElement.gb');
    return await buildJsIElementsElementGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIElementsElement(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIElementsElementGenerated } = await import('./iElementsElement.gb');
    return await buildDotNetIElementsElementGenerated(jsObject, viewId);
}
