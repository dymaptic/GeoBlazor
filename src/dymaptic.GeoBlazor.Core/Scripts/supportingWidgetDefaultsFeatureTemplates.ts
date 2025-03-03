
export async function buildJsSupportingWidgetDefaultsFeatureTemplates(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportingWidgetDefaultsFeatureTemplatesGenerated } = await import('./supportingWidgetDefaultsFeatureTemplates.gb');
    return await buildJsSupportingWidgetDefaultsFeatureTemplatesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportingWidgetDefaultsFeatureTemplates(jsObject: any): Promise<any> {
    let { buildDotNetSupportingWidgetDefaultsFeatureTemplatesGenerated } = await import('./supportingWidgetDefaultsFeatureTemplates.gb');
    return await buildDotNetSupportingWidgetDefaultsFeatureTemplatesGenerated(jsObject);
}
