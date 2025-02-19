
export async function buildJsFindResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFindResultGenerated } = await import('./findResult.gb');
    return await buildJsFindResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFindResult(jsObject: any): Promise<any> {
    let { buildDotNetFindResultGenerated } = await import('./findResult.gb');
    return await buildDotNetFindResultGenerated(jsObject);
}
