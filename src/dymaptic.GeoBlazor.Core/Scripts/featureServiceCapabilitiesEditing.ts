
export async function buildJsFeatureServiceCapabilitiesEditing(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceCapabilitiesEditingGenerated } = await import('./featureServiceCapabilitiesEditing.gb');
    return await buildJsFeatureServiceCapabilitiesEditingGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureServiceCapabilitiesEditing(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureServiceCapabilitiesEditingGenerated } = await import('./featureServiceCapabilitiesEditing.gb');
    return await buildDotNetFeatureServiceCapabilitiesEditingGenerated(jsObject, layerId, viewId);
}
