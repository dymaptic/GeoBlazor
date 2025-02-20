export async function buildJsServiceContents(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsServiceContentsGenerated} = await import('./serviceContents.gb');
    return await buildJsServiceContentsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetServiceContents(jsObject: any): Promise<any> {
    let {buildDotNetServiceContentsGenerated} = await import('./serviceContents.gb');
    return await buildDotNetServiceContentsGenerated(jsObject);
}
