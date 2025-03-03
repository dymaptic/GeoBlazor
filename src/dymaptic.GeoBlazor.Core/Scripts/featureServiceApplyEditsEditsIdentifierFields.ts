
export async function buildJsFeatureServiceApplyEditsEditsIdentifierFields(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureServiceApplyEditsEditsIdentifierFieldsGenerated } = await import('./featureServiceApplyEditsEditsIdentifierFields.gb');
    return await buildJsFeatureServiceApplyEditsEditsIdentifierFieldsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureServiceApplyEditsEditsIdentifierFields(jsObject: any): Promise<any> {
    let { buildDotNetFeatureServiceApplyEditsEditsIdentifierFieldsGenerated } = await import('./featureServiceApplyEditsEditsIdentifierFields.gb');
    return await buildDotNetFeatureServiceApplyEditsEditsIdentifierFieldsGenerated(jsObject);
}
