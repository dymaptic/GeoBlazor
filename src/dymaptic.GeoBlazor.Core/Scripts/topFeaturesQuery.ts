// override generated code in this file

export async function buildJsTopFeaturesQuery(dotNetObject: any): Promise<any> {
    let {buildJsTopFeaturesQueryGenerated} = await import('./topFeaturesQuery.gb');
    return await buildJsTopFeaturesQueryGenerated(dotNetObject);
}

export async function buildDotNetTopFeaturesQuery(jsObject: any): Promise<any> {
    let {buildDotNetTopFeaturesQueryGenerated} = await import('./topFeaturesQuery.gb');
    return await buildDotNetTopFeaturesQueryGenerated(jsObject);
}
