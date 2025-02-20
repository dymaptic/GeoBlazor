export async function buildJsFeatureTemplatesSelectEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureTemplatesSelectEventGenerated} = await import('./featureTemplatesSelectEvent.gb');
    return await buildJsFeatureTemplatesSelectEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureTemplatesSelectEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureTemplatesSelectEventGenerated} = await import('./featureTemplatesSelectEvent.gb');
    return await buildDotNetFeatureTemplatesSelectEventGenerated(jsObject);
}
