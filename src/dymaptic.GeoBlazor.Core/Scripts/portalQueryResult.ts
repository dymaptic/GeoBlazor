export async function buildJsPortalQueryResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalQueryResultGenerated} = await import('./portalQueryResult.gb');
    return await buildJsPortalQueryResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalQueryResult(jsObject: any): Promise<any> {
    let {buildDotNetPortalQueryResultGenerated} = await import('./portalQueryResult.gb');
    return await buildDotNetPortalQueryResultGenerated(jsObject);
}
