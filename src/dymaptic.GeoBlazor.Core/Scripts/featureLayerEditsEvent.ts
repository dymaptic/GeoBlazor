export async function buildJsFeatureLayerEditsEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFeatureLayerEditsEventGenerated} = await import('./featureLayerEditsEvent.gb');
    return await buildJsFeatureLayerEditsEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFeatureLayerEditsEvent(jsObject: any): Promise<any> {
    let {buildDotNetFeatureLayerEditsEventGenerated} = await import('./featureLayerEditsEvent.gb');
    return await buildDotNetFeatureLayerEditsEventGenerated(jsObject);
}
