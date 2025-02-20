export async function buildJsFeatureServiceApplyEditsEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureServiceApplyEditsEditsGenerated} = await import('./featureServiceApplyEditsEdits.gb');
    return await buildJsFeatureServiceApplyEditsEditsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureServiceApplyEditsEdits(jsObject: any): Promise<any> {
    let {buildDotNetFeatureServiceApplyEditsEditsGenerated} = await import('./featureServiceApplyEditsEdits.gb');
    return await buildDotNetFeatureServiceApplyEditsEditsGenerated(jsObject);
}
