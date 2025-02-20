export async function buildJsFromScreenPointResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFromScreenPointResultGenerated} = await import('./fromScreenPointResult.gb');
    return await buildJsFromScreenPointResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFromScreenPointResult(jsObject: any): Promise<any> {
    let {buildDotNetFromScreenPointResultGenerated} = await import('./fromScreenPointResult.gb');
    return await buildDotNetFromScreenPointResultGenerated(jsObject);
}
