// override generated code in this file

export async function buildJsTopFeaturesQuery(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTopFeaturesQueryGenerated} = await import('./topFeaturesQuery.gb');
    return await buildJsTopFeaturesQueryGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTopFeaturesQuery(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetTopFeaturesQueryGenerated} = await import('./topFeaturesQuery.gb');
    return await buildDotNetTopFeaturesQueryGenerated(jsObject, layerId, viewId);
}
