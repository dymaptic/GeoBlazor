export async function buildJsRelationshipUpdateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipUpdateRendererParamsGenerated } = await import('./relationshipUpdateRendererParams.gb');
    return await buildJsRelationshipUpdateRendererParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelationshipUpdateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipUpdateRendererParamsGenerated } = await import('./relationshipUpdateRendererParams.gb');
    return await buildDotNetRelationshipUpdateRendererParamsGenerated(jsObject);
}
