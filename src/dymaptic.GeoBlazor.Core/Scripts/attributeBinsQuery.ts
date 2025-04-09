
export async function buildJsAttributeBinsQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeBinsQueryGenerated } = await import('./attributeBinsQuery.gb');
    return await buildJsAttributeBinsQueryGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeBinsQuery(jsObject: any): Promise<any> {
    let { buildDotNetAttributeBinsQueryGenerated } = await import('./attributeBinsQuery.gb');
    return await buildDotNetAttributeBinsQueryGenerated(jsObject);
}
