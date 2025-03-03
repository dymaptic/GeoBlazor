
export async function buildJsIVersionAdapterVersionableItem(dotNetObject: any): Promise<any> {
    let { buildJsIVersionAdapterVersionableItemGenerated } = await import('./iVersionAdapterVersionableItem.gb');
    return await buildJsIVersionAdapterVersionableItemGenerated(dotNetObject);
}     

export async function buildDotNetIVersionAdapterVersionableItem(jsObject: any): Promise<any> {
    let { buildDotNetIVersionAdapterVersionableItemGenerated } = await import('./iVersionAdapterVersionableItem.gb');
    return await buildDotNetIVersionAdapterVersionableItemGenerated(jsObject);
}
