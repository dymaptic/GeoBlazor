
export async function buildJsTableListVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsTableListVisibleElementsGenerated } = await import('./tableListVisibleElements.gb');
    return await buildJsTableListVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetTableListVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetTableListVisibleElementsGenerated } = await import('./tableListVisibleElements.gb');
    return await buildDotNetTableListVisibleElementsGenerated(jsObject, viewId);
}
