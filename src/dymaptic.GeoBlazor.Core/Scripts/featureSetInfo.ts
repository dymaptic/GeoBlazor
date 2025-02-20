export async function buildJsFeatureSetInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureSetInfoGenerated} = await import('./featureSetInfo.gb');
    return await buildJsFeatureSetInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureSetInfo(jsObject: any): Promise<any> {
    let {buildDotNetFeatureSetInfoGenerated} = await import('./featureSetInfo.gb');
    return await buildDotNetFeatureSetInfoGenerated(jsObject);
}
