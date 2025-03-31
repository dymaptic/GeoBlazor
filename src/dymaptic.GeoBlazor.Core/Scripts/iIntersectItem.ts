
export async function buildJsIIntersectItem(dotNetObject: any): Promise<any> {
    let { buildJsIIntersectItemGenerated } = await import('./iIntersectItem.gb');
    return await buildJsIIntersectItemGenerated(dotNetObject);
}     

export async function buildDotNetIIntersectItem(jsObject: any): Promise<any> {
    let { buildDotNetIIntersectItemGenerated } = await import('./iIntersectItem.gb');
    return await buildDotNetIIntersectItemGenerated(jsObject);
}
