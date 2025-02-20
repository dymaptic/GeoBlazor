export async function buildJsFeatureFormValueChangeEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureFormValueChangeEventGenerated} = await import('./featureFormValueChangeEvent.gb');
    return await buildJsFeatureFormValueChangeEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureFormValueChangeEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureFormValueChangeEventGenerated} = await import('./featureFormValueChangeEvent.gb');
    return await buildDotNetFeatureFormValueChangeEventGenerated(jsObject);
}
