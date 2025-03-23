
export async function buildJsSupportingWidgetDefaults(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportingWidgetDefaultsGenerated } = await import('./supportingWidgetDefaults.gb');
    return await buildJsSupportingWidgetDefaultsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportingWidgetDefaults(jsObject: any): Promise<any> {
    let { buildDotNetSupportingWidgetDefaultsGenerated } = await import('./supportingWidgetDefaults.gb');
    return await buildDotNetSupportingWidgetDefaultsGenerated(jsObject);
}
