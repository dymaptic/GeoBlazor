
export async function buildJsIVersionAdapterVersionableItem(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIVersionAdapterVersionableItemGenerated } = await import('./iVersionAdapterVersionableItem.gb');
    return await buildJsIVersionAdapterVersionableItemGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIVersionAdapterVersionableItem(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIVersionAdapterVersionableItemGenerated } = await import('./iVersionAdapterVersionableItem.gb');
    return await buildDotNetIVersionAdapterVersionableItemGenerated(jsObject, viewId);
}
