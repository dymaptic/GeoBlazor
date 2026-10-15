
export async function buildJsFeatureFormViewModelValueChangeEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureFormViewModelValueChangeEventGenerated } = await import('./featureFormViewModelValueChangeEvent.gb');
    return await buildJsFeatureFormViewModelValueChangeEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureFormViewModelValueChangeEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureFormViewModelValueChangeEventGenerated } = await import('./featureFormViewModelValueChangeEvent.gb');
    return await buildDotNetFeatureFormViewModelValueChangeEventGenerated(jsObject, layerId, viewId);
}
