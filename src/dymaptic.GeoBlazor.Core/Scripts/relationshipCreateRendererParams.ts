export async function buildJsRelationshipCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsRelationshipCreateRendererParamsGenerated } = await import('./relationshipCreateRendererParams.gb');
    return await buildJsRelationshipCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetRelationshipCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetRelationshipCreateRendererParamsGenerated } = await import('./relationshipCreateRendererParams.gb');
    return await buildDotNetRelationshipCreateRendererParamsGenerated(jsObject);
}
