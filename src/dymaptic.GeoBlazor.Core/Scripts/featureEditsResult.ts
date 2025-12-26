
export async function buildJsFeatureEditsResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureEditsResultGenerated } = await import('./featureEditsResult.gb');
    return await buildJsFeatureEditsResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureEditsResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureEditsResultGenerated } = await import('./featureEditsResult.gb');
    return await buildDotNetFeatureEditsResultGenerated(jsObject, layerId, viewId);
}
