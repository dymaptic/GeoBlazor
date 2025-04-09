
export async function buildJsAttributeBinsFeatureSet(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAttributeBinsFeatureSetGenerated } = await import('./attributeBinsFeatureSet.gb');
    return await buildJsAttributeBinsFeatureSetGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAttributeBinsFeatureSet(jsObject: any): Promise<any> {
    let { buildDotNetAttributeBinsFeatureSetGenerated } = await import('./attributeBinsFeatureSet.gb');
    return await buildDotNetAttributeBinsFeatureSetGenerated(jsObject);
}
