// override generated code in this file            
export async function buildJsFeatureEdits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureEditsGenerated } = await import('./featureEdits.gb');
    return await buildJsFeatureEditsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetFeatureEdits(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeatureEditsGenerated } = await import('./featureEdits.gb');
    return await buildDotNetFeatureEditsGenerated(jsObject, layerId, viewId);
}
