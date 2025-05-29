
export async function buildJsAssetTypeJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAssetTypeJSONGenerated } = await import('./assetTypeJSON.gb');
    return await buildJsAssetTypeJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAssetTypeJSON(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAssetTypeJSONGenerated } = await import('./assetTypeJSON.gb');
    return await buildDotNetAssetTypeJSONGenerated(jsObject, layerId, viewId);
}
