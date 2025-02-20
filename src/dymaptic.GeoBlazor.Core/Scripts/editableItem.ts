export async function buildJsEditableItem(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsEditableItemGenerated} = await import('./editableItem.gb');
    return await buildJsEditableItemGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetEditableItem(jsObject: any): Promise<any> {
    let {buildDotNetEditableItemGenerated} = await import('./editableItem.gb');
    return await buildDotNetEditableItemGenerated(jsObject);
}
