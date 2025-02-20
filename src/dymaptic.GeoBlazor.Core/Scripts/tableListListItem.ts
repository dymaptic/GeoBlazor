export async function buildJsTableListListItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTableListListItemGenerated} = await import('./tableListListItem.gb');
    return await buildJsTableListListItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTableListListItem(jsObject: any): Promise<any> {
    let {buildDotNetTableListListItemGenerated} = await import('./tableListListItem.gb');
    return await buildDotNetTableListListItemGenerated(jsObject);
}
