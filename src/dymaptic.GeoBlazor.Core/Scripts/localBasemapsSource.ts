export async function buildJsLocalBasemapsSource(dotNetObject: any): Promise<any> {
    let {buildJsLocalBasemapsSourceGenerated} = await import('./localBasemapsSource.gb');
    return buildJsLocalBasemapsSourceGenerated(dotNetObject);
}

export async function buildDotNetLocalBasemapsSource(jsObject: any): Promise<any> {
    let {buildDotNetLocalBasemapsSourceGenerated} = await import('./localBasemapsSource.gb');
    return await buildDotNetLocalBasemapsSourceGenerated(jsObject);
}
