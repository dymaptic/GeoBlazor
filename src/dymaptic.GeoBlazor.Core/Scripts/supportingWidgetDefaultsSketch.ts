export async function buildJsSupportingWidgetDefaultsSketch(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportingWidgetDefaultsSketchGenerated } = await import('./supportingWidgetDefaultsSketch.gb');
    return await buildJsSupportingWidgetDefaultsSketchGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSupportingWidgetDefaultsSketch(jsObject: any): Promise<any> {
    let { buildDotNetSupportingWidgetDefaultsSketchGenerated } = await import('./supportingWidgetDefaultsSketch.gb');
    return await buildDotNetSupportingWidgetDefaultsSketchGenerated(jsObject);
}
