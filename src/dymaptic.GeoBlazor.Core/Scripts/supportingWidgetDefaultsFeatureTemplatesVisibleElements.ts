
export async function buildJsSupportingWidgetDefaultsFeatureTemplatesVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportingWidgetDefaultsFeatureTemplatesVisibleElementsGenerated } = await import('./supportingWidgetDefaultsFeatureTemplatesVisibleElements.gb');
    return await buildJsSupportingWidgetDefaultsFeatureTemplatesVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElementsGenerated } = await import('./supportingWidgetDefaultsFeatureTemplatesVisibleElements.gb');
    return await buildDotNetSupportingWidgetDefaultsFeatureTemplatesVisibleElementsGenerated(jsObject, layerId, viewId);
}
