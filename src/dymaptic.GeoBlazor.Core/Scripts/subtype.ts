
export async function buildJsSubtype(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsSubtypeGenerated } = await import('./subtype.gb');
    return await buildJsSubtypeGenerated(dotNetObject, viewId);
}     

export async function buildDotNetSubtype(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSubtypeGenerated } = await import('./subtype.gb');
    return await buildDotNetSubtypeGenerated(jsObject, viewId);
}
