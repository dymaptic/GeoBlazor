
export async function buildJsVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsVisibleElementsGenerated } = await import('./visibleElements.gb');
    return await buildJsVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetVisibleElementsGenerated } = await import('./visibleElements.gb');
    return await buildDotNetVisibleElementsGenerated(jsObject);
}
