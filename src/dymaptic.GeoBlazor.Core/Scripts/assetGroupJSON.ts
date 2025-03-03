
export async function buildJsAssetGroupJSON(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAssetGroupJSONGenerated } = await import('./assetGroupJSON.gb');
    return await buildJsAssetGroupJSONGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAssetGroupJSON(jsObject: any): Promise<any> {
    let { buildDotNetAssetGroupJSONGenerated } = await import('./assetGroupJSON.gb');
    return await buildDotNetAssetGroupJSONGenerated(jsObject);
}
