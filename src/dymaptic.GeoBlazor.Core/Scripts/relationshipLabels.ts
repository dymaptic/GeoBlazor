
export async function buildJsRelationshipLabels(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipLabelsGenerated } = await import('./relationshipLabels.gb');
    return await buildJsRelationshipLabelsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipLabels(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetRelationshipLabelsGenerated } = await import('./relationshipLabels.gb');
    return await buildDotNetRelationshipLabelsGenerated(jsObject, viewId);
}
