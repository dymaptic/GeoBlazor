export async function buildJsWFSFeatureType(dotNetObject: any): Promise<any> {
    let {buildJsWFSFeatureTypeGenerated} = await import('./wFSFeatureType.gb');
    return await buildJsWFSFeatureTypeGenerated(dotNetObject);
}

export async function buildDotNetWFSFeatureType(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetWFSFeatureTypeGenerated} = await import('./wFSFeatureType.gb');
    return await buildDotNetWFSFeatureTypeGenerated(jsObject, viewId);
}
