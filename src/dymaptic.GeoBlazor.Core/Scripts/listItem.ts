export async function buildJsListItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsListItemGenerated} = await import('./listItem.gb');
    return await buildJsListItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetListItem(jsObject: any): Promise<any> {
    let {buildDotNetListItemGenerated} = await import('./listItem.gb');
    return await buildDotNetListItemGenerated(jsObject);
}
