
export async function buildJsSubtype(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSubtypeGenerated } = await import('./subtype.gb');
    return await buildJsSubtypeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSubtype(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSubtypeGenerated } = await import('./subtype.gb');
    return await buildDotNetSubtypeGenerated(jsObject, layerId, viewId);
}
