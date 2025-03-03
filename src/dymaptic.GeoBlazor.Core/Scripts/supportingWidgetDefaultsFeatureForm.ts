
export async function buildJsSupportingWidgetDefaultsFeatureForm(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportingWidgetDefaultsFeatureFormGenerated } = await import('./supportingWidgetDefaultsFeatureForm.gb');
    return await buildJsSupportingWidgetDefaultsFeatureFormGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportingWidgetDefaultsFeatureForm(jsObject: any): Promise<any> {
    let { buildDotNetSupportingWidgetDefaultsFeatureFormGenerated } = await import('./supportingWidgetDefaultsFeatureForm.gb');
    return await buildDotNetSupportingWidgetDefaultsFeatureFormGenerated(jsObject);
}
