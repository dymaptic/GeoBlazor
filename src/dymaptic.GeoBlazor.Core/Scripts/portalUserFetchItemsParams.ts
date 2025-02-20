// override generated code in this file


export async function buildJsPortalUserFetchItemsParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPortalUserFetchItemsParamsGenerated} = await import('./portalUserFetchItemsParams.gb');
    return await buildJsPortalUserFetchItemsParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPortalUserFetchItemsParams(jsObject: any): Promise<any> {
    let {buildDotNetPortalUserFetchItemsParamsGenerated} = await import('./portalUserFetchItemsParams.gb');
    return await buildDotNetPortalUserFetchItemsParamsGenerated(jsObject);
}
