
export async function buildJsIIntersectItem(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIIntersectItemGenerated } = await import('./iIntersectItem.gb');
    return await buildJsIIntersectItemGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIIntersectItem(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIIntersectItemGenerated } = await import('./iIntersectItem.gb');
    return await buildDotNetIIntersectItemGenerated(jsObject, viewId);
}
