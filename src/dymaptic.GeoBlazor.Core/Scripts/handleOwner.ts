export async function buildJsHandleOwner(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsHandleOwnerGenerated} = await import('./handleOwner.gb');
    return await buildJsHandleOwnerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetHandleOwner(jsObject: any): Promise<any> {
    let {buildDotNetHandleOwnerGenerated} = await import('./handleOwner.gb');
    return await buildDotNetHandleOwnerGenerated(jsObject);
}
