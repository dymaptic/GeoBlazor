
export async function buildJsRelationshipRendererResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipRendererResultGenerated } = await import('./relationshipRendererResult.gb');
    return await buildJsRelationshipRendererResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetRelationshipRendererResult(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipRendererResultGenerated } = await import('./relationshipRendererResult.gb');
    return await buildDotNetRelationshipRendererResultGenerated(jsObject);
}
