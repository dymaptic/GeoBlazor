// override generated code in this file


export async function buildJsDeleteItemsResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsDeleteItemsResultGenerated} = await import('./deleteItemsResult.gb');
    return await buildJsDeleteItemsResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetDeleteItemsResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetDeleteItemsResultGenerated} = await import('./deleteItemsResult.gb');
    return await buildDotNetDeleteItemsResultGenerated(jsObject, layerId, viewId);
}
