
export async function buildJsLocalMediaElementSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLocalMediaElementSourceGenerated } = await import('./localMediaElementSource.gb');
    return await buildJsLocalMediaElementSourceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLocalMediaElementSource(jsObject: any): Promise<any> {
    let { buildDotNetLocalMediaElementSourceGenerated } = await import('./localMediaElementSource.gb');
    return await buildDotNetLocalMediaElementSourceGenerated(jsObject);
}
