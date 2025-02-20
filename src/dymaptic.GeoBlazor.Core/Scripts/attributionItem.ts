export async function buildJsAttributionItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsAttributionItemGenerated} = await import('./attributionItem.gb');
    return await buildJsAttributionItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetAttributionItem(jsObject: any): Promise<any> {
    let {buildDotNetAttributionItemGenerated} = await import('./attributionItem.gb');
    return await buildDotNetAttributionItemGenerated(jsObject);
}
