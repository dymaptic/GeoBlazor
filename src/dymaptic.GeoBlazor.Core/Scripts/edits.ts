export async function buildJsEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsEditsGenerated} = await import('./edits.gb');
    return await buildJsEditsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetEdits(jsObject: any): Promise<any> {
    let {buildDotNetEditsGenerated} = await import('./edits.gb');
    return await buildDotNetEditsGenerated(jsObject);
}
