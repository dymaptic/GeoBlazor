
export async function buildJsGroupElement(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupElementGenerated } = await import('./groupElement.gb');
    return await buildJsGroupElementGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupElement(jsObject: any): Promise<any> {
    let { buildDotNetGroupElementGenerated } = await import('./groupElement.gb');
    return await buildDotNetGroupElementGenerated(jsObject);
}
