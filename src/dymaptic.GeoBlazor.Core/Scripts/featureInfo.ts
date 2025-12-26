
export async function buildJsFeatureInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureInfoGenerated } = await import('./featureInfo.gb');
    return await buildJsFeatureInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureInfoGenerated } = await import('./featureInfo.gb');
    return await buildDotNetFeatureInfoGenerated(jsObject, viewId);
}
