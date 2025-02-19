
export async function buildJsImagePointResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImagePointResultGenerated } = await import('./imagePointResult.gb');
    return await buildJsImagePointResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetImagePointResult(jsObject: any): Promise<any> {
    let { buildDotNetImagePointResultGenerated } = await import('./imagePointResult.gb');
    return await buildDotNetImagePointResultGenerated(jsObject);
}
