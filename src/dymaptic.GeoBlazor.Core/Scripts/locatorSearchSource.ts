export async function buildJsLocatorSearchSource(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLocatorSearchSourceGenerated} = await import('./locatorSearchSource.gb');
    return await buildJsLocatorSearchSourceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLocatorSearchSource(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetLocatorSearchSourceGenerated} = await import('./locatorSearchSource.gb');
    return await buildDotNetLocatorSearchSourceGenerated(jsObject, viewId);
}
