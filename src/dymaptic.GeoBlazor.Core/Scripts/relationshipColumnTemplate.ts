
export async function buildJsRelationshipColumnTemplate(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipColumnTemplateGenerated } = await import('./relationshipColumnTemplate.gb');
    return await buildJsRelationshipColumnTemplateGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipColumnTemplate(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipColumnTemplateGenerated } = await import('./relationshipColumnTemplate.gb');
    return await buildDotNetRelationshipColumnTemplateGenerated(jsObject);
}
