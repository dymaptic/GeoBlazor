
export async function buildJsFeatureTemplatesViewModelSelectEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureTemplatesViewModelSelectEventGenerated } = await import('./featureTemplatesViewModelSelectEvent.gb');
    return await buildJsFeatureTemplatesViewModelSelectEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureTemplatesViewModelSelectEvent(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureTemplatesViewModelSelectEventGenerated } = await import('./featureTemplatesViewModelSelectEvent.gb');
    return await buildDotNetFeatureTemplatesViewModelSelectEventGenerated(jsObject, viewId);
}
