export async function buildJsWFSFeatureType(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWFSFeatureTypeGenerated } = await import('./wFSFeatureType.gb');
    return await buildJsWFSFeatureTypeGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetWFSFeatureType(jsObject: any): Promise<any> {
    let { buildDotNetWFSFeatureTypeGenerated } = await import('./wFSFeatureType.gb');
    return await buildDotNetWFSFeatureTypeGenerated(jsObject);
}
