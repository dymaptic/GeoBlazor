
export async function buildJsSubtype(dotNetObject: any): Promise<any> {
    let { buildJsSubtypeGenerated } = await import('./subtype.gb');
    return await buildJsSubtypeGenerated(dotNetObject);
}     

export async function buildDotNetSubtype(jsObject: any): Promise<any> {
    let { buildDotNetSubtypeGenerated } = await import('./subtype.gb');
    return await buildDotNetSubtypeGenerated(jsObject);
}
