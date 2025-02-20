export async function buildJsLocalBasemapsSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocalBasemapsSourceGenerated} = await import('./localBasemapsSource.gb');
    return await buildJsLocalBasemapsSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocalBasemapsSource(jsObject: any): Promise<any> {
    let {buildDotNetLocalBasemapsSourceGenerated} = await import('./localBasemapsSource.gb');
    return await buildDotNetLocalBasemapsSourceGenerated(jsObject);
}
