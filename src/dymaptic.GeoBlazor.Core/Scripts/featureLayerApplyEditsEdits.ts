
export async function buildJsFeatureLayerApplyEditsEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureLayerApplyEditsEditsGenerated } = await import('./featureLayerApplyEditsEdits.gb');
    return await buildJsFeatureLayerApplyEditsEditsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureLayerApplyEditsEdits(jsObject: any): Promise<any> {
    let { buildDotNetFeatureLayerApplyEditsEditsGenerated } = await import('./featureLayerApplyEditsEdits.gb');
    return await buildDotNetFeatureLayerApplyEditsEditsGenerated(jsObject);
}
