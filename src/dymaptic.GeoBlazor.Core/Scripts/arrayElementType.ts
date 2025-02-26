
export async function buildJsArrayElementType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsArrayElementTypeGenerated } = await import('./arrayElementType.gb');
    return await buildJsArrayElementTypeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetArrayElementType(jsObject: any): Promise<any> {
    let { buildDotNetArrayElementTypeGenerated } = await import('./arrayElementType.gb');
    return await buildDotNetArrayElementTypeGenerated(jsObject);
}
